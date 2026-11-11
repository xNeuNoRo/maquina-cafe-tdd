using Xunit;

namespace MaquinaCafe.Tests;

public class VasoTests
{
    [Fact]
    public void TieneVasos_DevuelveVerdadero_SiHaySuficientes()
    {
        var vasos = new Vaso(2, 10);

        Assert.True(vasos.TieneVasos(1));
    }

    [Fact]
    public void TieneVasos_DevuelveFalso_SiNoHaySuficientes()
    {
        var vasos = new Vaso(1, 10);

        Assert.False(vasos.TieneVasos(2));
    }

    [Fact]
    public void EntregarVasos_DescuentaLaCantidad()
    {
        var vasos = new Vaso(5, 10);

        vasos.EntregarVasos(1);

        Assert.Equal(4, vasos.CantidadVasos);
    }
}
