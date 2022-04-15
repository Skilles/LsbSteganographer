using System.Drawing.Imaging;

namespace Stenographer;

public class LsbProcessor
{
    public enum State
    {
        Unloaded,
        Ready,
        Encoded,
        Hiding,
        Filling_With_Zeros
    }

    private Bitmap? _bitmap;
    private readonly int _height;
    private readonly int _width;

    public LsbProcessor(int width, int height)
    {
        Status = State.Unloaded;
        _width = width;
        _height = height;
    }

    public State Status { get; private set; }

    ~LsbProcessor()
    {
        _bitmap?.Dispose();
    }

    // Saves the current bitmap to a file
    public void SaveImage(string fileName)
    {
        _bitmap?.Save(fileName, ImageFormat.Png);
    }

    // Loads a file as a bitmap
    public void LoadImage(string imagePath)
    {
        _bitmap?.Dispose();
        _bitmap = new Bitmap(Image.FromFile(imagePath));
        Status = State.Ready;
    }

    // Get the current bitmap as an image
    public Image GetImage()
    {
        if (_bitmap == null) throw new InvalidOperationException("No image loaded");
        return new Bitmap(_bitmap, _width, _height);
    }

    // Encodes text into the current bitmap
    public void EncodeText(string text)
    {
        if (Status != State.Ready) throw new InvalidOperationException($"LSB is not ready! State = {Status}");
        // initially hide characters in the image
        Status = State.Hiding;

        // holds the index of the character that is being hidden
        var charIndex = 0;

        // holds the value of the character converted to integer
        var charValue = 0;

        // holds the index of the color element (R or G or B) that is currently being processed
        long pixelElementIndex = 0;

        // holds the number of trailing zeros that have been added when finishing the process
        var zeros = 0;

        // hold pixel elements

        for (var i = 0; i < _bitmap.Height; i++)
        for (var j = 0; j < _bitmap.Width; j++)
        {
            var color = _bitmap.GetPixel(j, i);
            var R = color.R - color.R % 2;
            var G = color.G - color.G % 2;
            var B = color.B - color.B % 2;
            // for each pixel, pass through its elements (RGB)
            for (var n = 0; n < 3; n++)
            {
                // check if new 8 bits has been processed
                if (pixelElementIndex % 8 == 0)
                {
                    // check if the whole process has finished
                    // we can say that it's finished when 8 zeros are added
                    if (Status == State.Filling_With_Zeros && zeros == 8)
                    {
                        // apply the last pixel on the image
                        // even if only a part of its elements have been affected
                        if ((pixelElementIndex - 1) % 3 < 2)
                            _bitmap.SetPixel(j, i, Color.FromArgb(R, G, B));
                        // bmp.SetPixel(j, i, Color.FromArgb(R, G, B));

                        // return the bitmap with the text hidden in
                        Status = State.Encoded;
                        return;
                    }

                    // check if all characters has been hidden
                    if (charIndex >= text.Length)
                        // start adding zeros to mark the end of the text
                        Status = State.Filling_With_Zeros;
                    else
                        // move to the next character and process again
                        charValue = text[charIndex++];
                }

                // check which pixel element has the turn to hide a bit in its LSB
                switch (pixelElementIndex % 3)
                {
                    case 0:
                    {
                        if (Status == State.Hiding)
                        {
                            // the rightmost bit in the character will be (charValue % 2)
                            // to put this value instead of the LSB of the pixel element
                            // just add it to it
                            // recall that the LSB of the pixel element had been cleared
                            // before this operation
                            R += charValue % 2;

                            // removes the added rightmost bit of the character
                            // such that next time we can reach the next one
                            charValue /= 2;
                        }
                    }
                        break;
                    case 1:
                    {
                        if (Status == State.Hiding)
                        {
                            G += charValue % 2;

                            charValue /= 2;
                        }
                    }
                        break;
                    case 2:
                    {
                        if (Status == State.Hiding)
                        {
                            B += charValue % 2;

                            charValue /= 2;
                        }

                        _bitmap.SetPixel(j, i, Color.FromArgb(R, G, B));
                    }
                        break;
                }

                pixelElementIndex++;

                if (Status == State.Filling_With_Zeros)
                    // increment the value of zeros until it is 8
                    zeros++;
            }
        }

        Status = State.Encoded;
    }

    // Decodes text from the current bitmap. Returns "" if no text found.
    public string DecodeText()
    {
        if (Status != State.Encoded && Status != State.Ready)
            throw new InvalidOperationException($"LSB is not encoded! State = {Status}");

        var colorUnitIndex = 0;
        var charValue = 0;

        // holds the text that will be extracted from the image
        var extractedText = string.Empty;

        for (var i = 0; i < _bitmap.Height; i++)
        for (var j = 0; j < _bitmap.Width; j++)
        {
            var pixel = _bitmap.GetPixel(j, i);

            // for each pixel, pass through its elements (RGB)
            for (var n = 0; n < 3; n++)
            {
                charValue = (colorUnitIndex % 3) switch
                {
                    0 =>
                        // get the LSB from the pixel element (will be pixel.R % 2)
                        // then add one bit to the right of the current character
                        // this can be done by (charValue = charValue * 2)
                        // replace the added bit (which value is by default 0) with
                        // the LSB of the pixel element, simply by addition
                        charValue * 2 + pixel.R % 2,
                    1 => charValue * 2 + pixel.G % 2,
                    2 => charValue * 2 + pixel.B % 2,
                    _ => charValue
                };

                colorUnitIndex++;

                // if 8 bits has been added,
                // then add the current character to the result text
                if (colorUnitIndex % 8 != 0) continue;
                // reverse? of course, since each time the process occurs
                // on the right (for simplicity)
                charValue = ReverseBits(charValue);

                // can only be 0 if it is the stop character (the 8 zeros)
                if (charValue == 0) return extractedText;

                // convert the character value from int to char
                var c = (char) charValue;

                // add the current character to the result text
                extractedText += c.ToString();
            }
        }

        static int ReverseBits(int n)
        {
            var result = 0;

            for (var i = 0; i < 8; i++)
            {
                result = result * 2 + n % 2;

                n /= 2;
            }

            return result;
        }

        return extractedText;
    }
}