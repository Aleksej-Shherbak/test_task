using GeometryLibrary;
using GeometryLibrary.Shapes;
using Xunit;

namespace Tests;

public class Tests
{

    [Fact]
    public void GetArea_ReturnsArea_When_CircleIsGiven()
    {
        // arrange
        var radius = 5;
        var circle = new Circle(radius);
        
        // act
        var result = circle.GetArea();

        // assert
        /*
         * Деление модуля разности между фактической площадью и ожидаемой площадью на ожидаемую площадь необходимо
         * для вычисления относительной ошибки. Относительная ошибка является мерой точности вычислений и вычисляется
         * как отношение абсолютной ошибки к истинному значению. В данном случае, мы используем относительную ошибку
         * для определения, насколько близко полученное значение площади круга к ожидаемому значению площади круга,
         * с учетом погрешности округления. Если бы мы проверяли точное значение площади круга, мы могли бы
         * использовать Assert.Equal(expectedArea, result) для проверки, что полученное значение равно ожидаемому
         * значению. Однако, при работе с вещественными числами мы должны учитывать погрешности округления.
         * Поэтому мы используем относительную ошибку, чтобы проверить, что полученное значение площади круга близко
         * к ожидаемому значению площади, с учетом погрешности округления. Если относительная ошибка меньше заданного
         * порога точности, то мы считаем, что тест пройден успешно.
         */
        
        var expectedArea = Math.PI * radius * radius;
        var relativeError = Math.Abs(result - expectedArea) / expectedArea;
        Assert.True(relativeError <= Double.Epsilon);
    }
    
    [Fact]
    public void IsRightAngled_ReturnsFalse_When_TriangleIsNotRightAngled()
    {
        // arrange
        var triangle = new Triangle(6, 6, 10);

        // act
        var result = triangle.IsRightAngled();

        // assert
        Assert.False(result);
    }
    
    [Fact]
    public void GetArea_ReturnsArea_When_TriangleIsGiven()
    {
        // arrange
        var triangle = new Triangle(15, 10);
        double expectedArea = 75;
        
        // act
        var result = triangle.GetArea();

        // assert
       Assert.True(Math.Abs(expectedArea - result) <= double.Epsilon);
    }
    
    [Fact]
    public void TriangleConstructor_ThrowsArgumentException_When_InadequateSideValuesGiven()
    {
        // arrange, act, assert
        Assert.Throws<ArgumentException>(() => new Triangle(-1, 2, 3));
        Assert.Throws<ArgumentException>(() => new Triangle(1, -2, 3));
        Assert.Throws<ArgumentException>(() => new Triangle(1, 2, -3));
        Assert.Throws<ArgumentException>(() => new Triangle(0, 2, 3));
        Assert.Throws<ArgumentException>(() => new Triangle(1, 0, 3));
        Assert.Throws<ArgumentException>(() => new Triangle(1, 2, 0));
        Assert.Throws<ArgumentException>(() => new Triangle(5, 5, 666));
    }
}