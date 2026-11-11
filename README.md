# Máquina de Café - Práctica de TDD (C#)

Proyecto para **Introducción a la Ingeniería de Software**, desarrollado en C# y .NET 8 a partir de la práctica de TDD «Máquina de Café».

**Autor:** Angel Gonzalez · 2025-1122

## Requisitos

- .NET SDK 8.0.
- Internet para restaurar los paquetes de pruebas de NuGet.

## Ejecutar

```bash
dotnet run --project src/MaquinaCafe/MaquinaCafe.csproj
```

La aplicación permite elegir el tamaño de vaso y las cucharadas de azúcar; valida las existencias antes de descontar los recursos.

## Pruebas TDD

```bash
dotnet test MaquinaCafe.sln
```

El proyecto utiliza xUnit con **21 pruebas** que cubren vasos, cafetera, azucarero y preparación de café.

## Estructura

```text
src/MaquinaCafe/           Aplicación de consola (.NET 8)
tests/MaquinaCafe.Tests/   Pruebas unitarias (xUnit)
MaquinaCafe.sln            Solución .NET
```
