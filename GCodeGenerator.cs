using System;

public class GCodeGenerator
{
    public static void Main()
    {
        double centerX = -26.752;
        double centerY = 87.502;
        double endMillDiameter = 12.0;
        double feedRate = 500;
        double ellipseWidth = 10;
        double ellipseHeight = 5;

        string gCode = GenerateGCode(centerX, centerY, endMillDiameter, feedRate, ellipseWidth, ellipseHeight);
        Console.WriteLine(gCode);
    }

    public static string GenerateGCode(double centerX, double centerY, double endMillDiameter, double feedRate, double ellipseWidth, double ellipseHeight)
    {
        // Calcular as posições iniciais e finais
        double startX = centerX - ellipseWidth / 2;
        double startY = centerY;

        // Construir o código G
        string gCode = "";
        gCode += $"G90 G01 X{startX} Y{startY} Z-8.5 F{feedRate}" + Environment.NewLine;

        // Gerar código G para a elipse usando arcos
        int numArcs = 8;
        double angleIncrement = 360.0 / numArcs;
        for (int i = 0; i < numArcs; i++)
        {
            double startAngle = i * angleIncrement;
            double endAngle = (i + 1) * angleIncrement;
            double midAngle = (startAngle + endAngle) / 2;

            double endX = centerX + (ellipseWidth / 2) * Math.Cos(endAngle * Math.PI / 180);
            double endY = centerY + (ellipseHeight / 2) * Math.Sin(endAngle * Math.PI / 180);

            double midX = centerX + (ellipseWidth / 2) * Math.Cos(midAngle * Math.PI / 180);
            double midY = centerY + (ellipseHeight / 2) * Math.Sin(midAngle * Math.PI / 180);

            double iValue = midX - startX;
            double jValue = midY - startY;

            string gCommand = (i % 2 == 0) ? "G02" : "G03";

            gCode += $"{gCommand} X{endX} Y{endY} I{iValue} J{jValue} F{feedRate}" + Environment.NewLine;

            startX = endX;
            startY = endY;
        }

        return gCode;
    }

}
public class GCodeGenerator
{
    public static void Main()
    {
        double centerX = -26.752;
        double centerY = 87.502;
        double endMillDiameter = 12.0;
        double feedRate = 500;
        double ellipseWidth = 10;
        double ellipseHeight = 5;

        string gCode = GenerateGCode(centerX, centerY, endMillDiameter, feedRate, ellipseWidth, ellipseHeight);
        Console.WriteLine(gCode);
    }

    public static string GenerateGCode(double centerX, double centerY, double endMillDiameter, double feedRate, double ellipseWidth, double ellipseHeight)
    {
        string gCode = "";

        int numArcs = 8;
        double angleIncrement = 360.0 / numArcs;

        double prevX = centerX - (ellipseWidth / 2) - (endMillDiameter / 2);
        double prevY = centerY;

        gCode += $"G90 G01 X{prevX} Y{prevY} Z-8.5 F{feedRate}" + Environment.NewLine;

        for (int i = 1; i <= numArcs; i++)
        {
            double startAngle = (i - 1) * angleIncrement;
            double endAngle = i * angleIncrement;

            double startX = centerX + (ellipseWidth / 2) * Math.Cos(startAngle * Math.PI / 180);
            double startY = centerY + (ellipseHeight / 2) * Math.Sin(startAngle * Math.PI / 180);

            double endX = centerX + (ellipseWidth / 2) * Math.Cos(endAngle * Math.PI / 180);
            double endY = centerY + (ellipseHeight / 2) * Math.Sin(endAngle * Math.PI / 180);

            double angleOffset = Math.Atan2(endY - startY, endX - startX);
            double offsetX = (endMillDiameter / 2) * Math.Cos(angleOffset);
            double offsetY = (endMillDiameter / 2) * Math.Sin(angleOffset);

            double arcCenterX = startX + offsetX;
            double arcCenterY = startY + offsetY;

            double iValue = arcCenterX - prevX;
            double jValue = arcCenterY - prevY;

            gCode += $"G03 X{endX} Y{endY} I{iValue} J{jValue} F{feedRate}" + Environment.NewLine;

            prevX = endX;
            prevY = endY;
        }

        return gCode;
    }
}

}
