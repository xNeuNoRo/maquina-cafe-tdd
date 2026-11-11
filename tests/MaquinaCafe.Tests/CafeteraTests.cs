using Xunit;

namespace MaquinaCafe.Tests;

public class CafeteraTests
{
    [Fact]
    public void TieneCafe_DevuelveVerdadero_SiHaySuficiente()
    {
        var cafetera = new Cafetera(10);

        Assert.True(cafetera.TieneCafe(5));
    }

    [Fact]
    public void TieneCafe_DevuelveFalso_SiNoHaySuficiente()
    {
        var cafetera = new Cafetera(10);

        Assert.False(cafetera.TieneCafe(11));
    }

    [Fact]
    public void EntregarCafe_DescuentaLaCantidad()
    {
        var cafetera = new Cafetera(10);

        cafetera.EntregarCafe(7);

        Assert.Equal(3, cafetera.CantidadCafe);
    }
}
