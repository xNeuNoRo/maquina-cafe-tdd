using Xunit;

namespace MaquinaCafe.Tests;

public class AzucareroTests
{
    [Fact]
    public void TieneAzucar_DevuelveVerdadero_SiHaySuficiente()
    {
        var azucarero = new Azucarero(10);

        Assert.True(azucarero.TieneAzucar(5));
        Assert.True(azucarero.TieneAzucar(10));
    }

    [Fact]
    public void TieneAzucar_DevuelveFalso_SiNoHaySuficiente()
    {
        var azucarero = new Azucarero(10);

        Assert.False(azucarero.TieneAzucar(15));
    }

    [Fact]
    public void EntregarAzucar_DescuentaLaCantidad()
    {
        var azucarero = new Azucarero(10);

        azucarero.EntregarAzucar(5);
        Assert.Equal(5, azucarero.CantidadAzucar);

        azucarero.EntregarAzucar(2);
        Assert.Equal(3, azucarero.CantidadAzucar);
    }
}
