using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Simulator.Maps;

//NOTATKI

//juz po restrukturyzacji(Commit SmallMap)
//stwory poruszaja sie po mapie i wiedza gdzie sie znajduja
//mapa wie kto jest na jej polach i gdzie
//dopuszczamy ze kilka stworow moze byc w jednym punkcie mapy
//Remove(...) ma miec parametry stwor i pozycje
//Move(...) ma miec 3 parametry stwor postion next
//Move(...) ma usuwac stwora z aktualnej pozycji i potem dodac go na nastepna pozycje
//Metoda At(...)
//W zadaniu domowym w symulatorze zakladamy ze sa 3 stwory
//Metoda Go stwora informuje mape ze trzeba stwora przestawic na mapie
//Konsola w zadaniu domowym pracuje w trybie unicodu





/// <summary>
/// Map of points.
/// </summary>
public abstract class Map
{
    public int SizeX { get; }
    public int SizeY { get; }

    public abstract void Add(Creature creature, Point position);

    public abstract void Remove(Creature creature, Point position);

    //public abstract List<>


    private readonly Rectangle _map;
    protected Map(int sizeX, int sizeY)
    {
        if (SizeX < 5)
        {
            throw new ArgumentOutOfRangeException(nameof(SizeX), "Too narrow");
        }
        if (SizeY < 5)
        {
            throw new ArgumentOutOfRangeException(nameof(SizeY), "Too short");
        }

        SizeX = sizeX;
        SizeY = sizeY;

        _map = new Rectangle(0, 0, SizeX - 1, SizeY - 1);
    }




    /// <summary>
    /// Check if give point belongs to the map.
    /// </summary>
    /// <param name="p">Point to check.</param>
    /// <returns></returns>
    public abstract bool Exist(Point p);
    public override bool Exist(Point p) => p.X >= 0 && p.X < Size && p.Y >= 0 && p.Y < Size;
    /// <summary>
    /// Next position to the point in a given direction.
    /// </summary>
    /// <param name="p">Starting point.</param>
    /// <param name="d">Direction.</param>
    /// <returns>Next point.</returns>
    public abstract Point Next(Point p, Direction d);
    /// <summary>
    /// Next diagonal position to the point in a given direction 
    /// rotated 45 degrees clockwise.
    /// </summary>
    /// <param name="p">Starting point.</param>
    /// <param name="d">Direction.</param>
    /// <returns>Next point.</returns>
    public abstract Point NextDiagonal(Point p, Direction d);
}