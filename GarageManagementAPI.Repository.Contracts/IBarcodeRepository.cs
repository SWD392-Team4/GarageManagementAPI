using System.Drawing;

namespace GarageManagementAPI.Repository.Contracts
{
    public interface IBarcodeRepository
    {
        Bitmap GenerateCode128Barcode(string barcodeText, int width = 300, int height = 100);
        byte[] GenerateBarcodeAsByteArray(string barcodeText, int width = 300, int height = 100);
    }
}