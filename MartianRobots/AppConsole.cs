using MartianRobots.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MartianRobots
{
    public class AppConsole : IAppConsole
    {
        List<Robot> robotList = new List<Robot>();
        public void Execute()
        {
            int x, y;
            string coordenada;
            string instruccion;
            char letra = 'S';
            bool coord = false;
            string dime;
            string[] dimension;

            List<Robot> robotLost = new List<Robot>();

            string s = "Bienvenido a centro de mando\n";
            Console.SetCursorPosition((Console.WindowWidth - s.Length) / 2, Console.CursorTop);
            Console.WriteLine(s);

            do
            {
                do
                {
                    Console.WriteLine("Ingrese primero las coordenadas(x, y) de la dimension del mundo rectangular, \ndeben ser menor a 50 y separadas por un espacio en blanco entre si: ");
                    dime = Console.ReadLine();

                } while (dime.Split().Length != 2);

                dimension = dime.Split(" ");
            } while (int.Parse(dimension[0]) > 50 && int.Parse(dimension[1]) > 50);

            x = int.Parse(dimension[0]);
            y = int.Parse(dimension[1]);
            Planet planet = new Planet(x, y);

            do
            {
                do
                {

                    Console.WriteLine("Ingrese una coordenada(x,y) de robot y su orientacion(N,S,E,W) separados por espacios en blanco entre ellas: ");
                    coordenada = Console.ReadLine().ToUpper();

                    if (coordenada.Split().Length == 3)
                    {
                        coord = true;

                        if (coord == true && coordenada[4] != 'N' && coordenada[4] != 'S' && coordenada[4] != 'E' && coordenada[4] != 'W')
                        {
                            Console.WriteLine("Error en el ingreso de datos");
                            coord = false;
                        }
                    }
                    else { Console.WriteLine("Error, debe ingresar las coordenadas y la orientacion separadas por un espacio en blanco"); }

                } while (coord == false);

                string[] cor = coordenada.Split(" ");
                x = int.Parse(cor[0]);/// cambiar esto por dos variables y no por un arreglo
                y = int.Parse(cor[1]);

                char orientacion = char.Parse(cor[2]);

                Robot currentRobot = new Robot(x, y, orientacion);

                do
                {
                    Console.WriteLine("Ingrese las instrucciones de robot(maximo 100 coordenadas):");
                    instruccion = Console.ReadLine().ToUpper();
                    if (instruccion.Length > 100)
                    {
                        Console.WriteLine("Ha ingresado mas de 100 caracteres en la cadena de instrucion");
                        coord = false;
                    }
                } while (coord == false);


                foreach (var inst in instruccion)
                {
                    bool cont = true;
                    if (inst == 'F')
                    {
                        foreach (var robot in robotLost)
                        {
                            if (robot.CurrentCoordinates == currentRobot.CurrentCoordinates && robot._orientation == currentRobot._orientation)
                            {
                                cont = false;
                                break;
                            }
                        }
                        if (cont)
                        {
                            if (currentRobot.CurrentCoordinates.X == planet.Dimension.X && currentRobot._orientation == 'E')
                            {
                                robotLost.Add(currentRobot);
                                currentRobot.IsLost = true;
                                break;
                            }
                            else if (currentRobot.CurrentCoordinates.X == 0 && currentRobot._orientation == 'W')
                            {
                                robotLost.Add(currentRobot);
                                currentRobot.IsLost = true;
                                break;
                            }
                            else if (currentRobot.CurrentCoordinates.Y == planet.Dimension.Y && currentRobot._orientation == 'N')
                            {
                                robotLost.Add(currentRobot);
                                currentRobot.IsLost = true;
                                break;
                            }
                            else if (currentRobot.CurrentCoordinates.Y == 0 && currentRobot._orientation == 'S')
                            {

                                currentRobot.IsLost = true;
                                break;
                            }
                            else { currentRobot.Move(inst); }
                        }
                        else { continue; }

                    }
                    else { currentRobot.Move(inst); }

                }
                robotList.Add(currentRobot);

                Console.WriteLine("Desea ingresar otro robot(S/N)");
                letra = char.Parse(Console.ReadLine().ToUpper());

            } while (letra == 'S');

            Console.WriteLine("Ingrese cualquier tecla para terminar para saber las coordenadas finales de los robot");

            Console.Read();
        }
        public void Exit()
        {
            foreach (var robot in robotList)
            {
                if (robot.IsLost == true)
                {
                    Console.WriteLine("La posicion del robot es: " + robot.CurrentCoordinates + " " + robot._orientation + " LOST");
                }
                else
                {
                    Console.WriteLine("La posicion del robot es: " + robot.CurrentCoordinates + " " + robot._orientation);
                }
            }
        }
    }
}