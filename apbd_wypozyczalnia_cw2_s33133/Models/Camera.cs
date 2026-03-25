namespace apbd_wypozyczalnia_cw2_s33133.Models;

public class Camera : Equipment
{
    public int Megapixels { get; set; }
    public bool HasOpticalZoom { get; set; }

    public Camera(int id, string name, int megapixels, bool hasOpticalZoom)
        : base(id, name)
    {
        Megapixels = megapixels;
        HasOpticalZoom = hasOpticalZoom;
    }

    public override string ToString()
    {
        return base.ToString() + $", MP: {Megapixels}, Optical Zoom: {HasOpticalZoom}";
    }
}