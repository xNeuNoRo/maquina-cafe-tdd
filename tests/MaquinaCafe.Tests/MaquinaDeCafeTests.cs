using Xunit;

namespace MaquinaCafe.Tests;

public class MaquinaDeCafeTests
{
    private readonly Cafetera _cafetera = new(50);
    private readonly Vaso _vasosPequenos = new(5, 10);
    private readonly Vaso _vasosMedianos = new(5, 20);
    private readonly Vaso _vasosGrandes = new(5, 30);
    private readonly Azucarero _azucarero = new(20);
    private readonly MaquinaDeCafe _maquina;

    public MaquinaDeCafeTests()
    {
        _maquina = new MaquinaDeCafe(
            _cafetera,
            _vasosPequenos,
            _vasosMedianos,
            _vasosGrandes,
            _azucarero
        );
    }

    [Fact]
    public void GetTipoDeVaso_DevuelvePequeno()
    {
        Assert.Same(_vasosPequenos, _maquina.GetTipoDeVaso("pequeno"));
    }

    [Fact]
    public void GetTipoDeVaso_DevuelveMediano()
    {
        Assert.Same(_vasosMedianos, _maquina.GetTipoDeVaso("mediano"));
    }

    [Fact]
    public void GetTipoDeVaso_DevuelveGrande()
    {
        Assert.Same(_vasosGrandes, _maquina.GetTipoDeVaso("grande"));
    }

    [Fact]
    public void GetVasoDeCafe_InformaCuandoFaltanVasos()
    {
        Assert.Equal("No hay Vasos", _maquina.GetVasoDeCafe(_vasosPequenos, 10, 2));
    }

    [Fact]
    public void GetVasoDeCafe_InformaCuandoFaltaCafe()
    {
        var maquina = new MaquinaDeCafe(
            new Cafetera(5),
            _vasosPequenos,
            _vasosMedianos,
            _vasosGrandes,
            _azucarero
        );

        Assert.Equal("No hay Cafe", maquina.GetVasoDeCafe(_vasosPequenos, 1, 2));
    }

    [Fact]
    public void GetVasoDeCafe_InformaCuandoFaltaAzucar()
    {
        var maquina = new MaquinaDeCafe(
            _cafetera,
            _vasosPequenos,
            _vasosMedianos,
            _vasosGrandes,
            new Azucarero(2)
        );

        Assert.Equal("No hay Azucar", maquina.GetVasoDeCafe(_vasosPequenos, 1, 3));
    }

    [Fact]
    public void GetVasoDeCafe_DescuentaCafe()
    {
        _maquina.GetVasoDeCafe(_vasosPequenos, 1, 3);

        Assert.Equal(40, _cafetera.CantidadCafe);
    }

    [Fact]
    public void GetVasoDeCafe_DescuentaVasos()
    {
        _maquina.GetVasoDeCafe(_vasosPequenos, 1, 3);

        Assert.Equal(4, _vasosPequenos.CantidadVasos);
    }

    [Fact]
    public void GetVasoDeCafe_DescuentaAzucar()
    {
        _maquina.GetVasoDeCafe(_vasosPequenos, 1, 3);

        Assert.Equal(17, _azucarero.CantidadAzucar);
    }

    [Fact]
    public void GetVasoDeCafe_DevuelveFelicitaciones_SiTieneTodo()
    {
        Assert.Equal("Felicitaciones", _maquina.GetVasoDeCafe(_vasosPequenos, 1, 3));
    }

    [Fact]
    public void GetVasoDeCafe_NoDescuentaNada_SiFaltaAzucar()
    {
        var maquina = new MaquinaDeCafe(
            _cafetera,
            _vasosPequenos,
            _vasosMedianos,
            _vasosGrandes,
            new Azucarero(0)
        );

        Assert.Equal("No hay Azucar", maquina.GetVasoDeCafe(_vasosPequenos, 1, 3));
        Assert.Equal(50, _cafetera.CantidadCafe);
        Assert.Equal(5, _vasosPequenos.CantidadVasos);
    }

    [Fact]
    public void GetVasoDeCafe_DescuentaIngredientes_ParaDosVasos()
    {
        Assert.Equal("Felicitaciones", _maquina.GetVasoDeCafe(_vasosPequenos, 2, 3));
        Assert.Equal(3, _vasosPequenos.CantidadVasos);
        Assert.Equal(30, _cafetera.CantidadCafe);
        Assert.Equal(14, _azucarero.CantidadAzucar);
    }
}
