using Hotel.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Services
{
    public class DataBaseInitializer : DropCreateDatabaseIfModelChanges<DataBaseContext>
    {
        protected override void Seed(DataBaseContext context)
        {
            City city1 = new City() { CityName = "Краснодар"};
            City city2 = new City() { CityName = "Саратов" };
            City city3 = new City() { CityName = "Москва" };
            City city4 = new City() { CityName = "Санкт-Петербург" };
            City city5 = new City() { CityName = "Ростов" };

            context.Citys.Add(city1);
            context.Citys.Add(city2);
            context.Citys.Add(city3);
            context.Citys.Add(city4);
            context.Citys.Add(city5);
            context.SaveChanges();

            Hotels hotel1 = new Hotels() { HotelName = "Мартон", CityId = 1 };
            Hotels hotel2 = new Hotels() { HotelName = "Марриотт", CityId = 1 };
            Hotels hotel3 = new Hotels() { HotelName = "Волга", CityId = 2 };
            Hotels hotel4 = new Hotels() { HotelName = "Олимпия", CityId = 2 };
            Hotels hotel5 = new Hotels() { HotelName = "Националь", CityId = 3 };
            Hotels hotel6 = new Hotels() { HotelName = "Метрополь", CityId = 3 };
            Hotels hotel7 = new Hotels() { HotelName = "Калейдоскоп Голд", CityId = 4 };
            Hotels hotel8 = new Hotels() { HotelName = "Дворец Трезини", CityId = 4 };
            Hotels hotel9 = new Hotels() { HotelName = "Русское подворье", CityId = 5 };
            Hotels hotel10 = new Hotels() { HotelName = "Рождественский", CityId = 5 };

            context.Hotels.Add(hotel1);
            context.Hotels.Add(hotel2);
            context.Hotels.Add(hotel3);
            context.Hotels.Add(hotel4);
            context.Hotels.Add(hotel5);
            context.Hotels.Add(hotel6);
            context.Hotels.Add(hotel7);
            context.Hotels.Add(hotel8);
            context.Hotels.Add(hotel9);
            context.Hotels.Add(hotel10);
            context.SaveChanges();

            Room room1Hotel1 = new Room() { Type = "Стнадарт двухместный", BedNum = 1, Prise = 2000, HotelId = 1, IsFree = true };
            Room room2Hotel1 = new Room() { Type = "Стнадарт трёхместный", BedNum = 2, Prise = 3500, HotelId = 1, IsFree = false }; 
            Room room3Hotel1 = new Room() { Type = "Люкс двухместный", BedNum = 1, Prise = 5500, HotelId = 1, IsFree = true };

            Room room1Hotel2 = new Room() { Type = "Стнадарт двухместный", BedNum = 1, Prise = 4000, HotelId = 2, IsFree = false };
            Room room2Hotel2 = new Room() { Type = "Стнадарт трёхместный", BedNum = 2, Prise = 5500, HotelId = 2, IsFree = false }; 
            Room room3Hotel2 = new Room() { Type = "Люкс двухместный", BedNum = 1, Prise = 8000, HotelId = 2, IsFree = true };

            Room room1Hotel3 = new Room() { Type = "Стнадарт двухместный", BedNum = 1, Prise = 2000, HotelId = 3, IsFree = true };
            Room room2Hotel3 = new Room() { Type = "Стнадарт трёхместный", BedNum = 2, Prise = 3500, HotelId = 3, IsFree = true };
            Room room3Hotel3 = new Room() { Type = "Люкс двухместный", BedNum = 1, Prise = 5500, HotelId = 3, IsFree = true };

            Room room1Hotel4 = new Room() { Type = "Стнадарт двухместный", BedNum = 1, Prise = 3000, HotelId = 4, IsFree = true };
            Room room2Hotel4 = new Room() { Type = "Стнадарт трёхместный", BedNum = 2, Prise = 5000, HotelId = 4, IsFree = false };
            Room room3Hotel4 = new Room() { Type = "Люкс двухместный", BedNum = 1, Prise = 7500, HotelId = 4, IsFree = false };

            Room room1Hotel5 = new Room() { Type = "Стнадарт двухместный", BedNum = 1, Prise = 10000, HotelId = 5, IsFree = true };
            Room room2Hotel5 = new Room() { Type = "Стнадарт трёхместный", BedNum = 2, Prise = 12000, HotelId = 5, IsFree = true };
            Room room3Hotel5 = new Room() { Type = "Люкс двухместный", BedNum = 1, Prise = 18000, HotelId = 5, IsFree = true };

            Room room1Hotel6 = new Room() { Type = "Стнадарт двухместный", BedNum = 1, Prise = 9000, HotelId = 6, IsFree = false };
            Room room2Hotel6 = new Room() { Type = "Стнадарт трёхместный", BedNum = 2, Prise = 13500, HotelId = 6, IsFree = false };
            Room room3Hotel6 = new Room() { Type = "Люкс двухместный", BedNum = 1, Prise = 17800, HotelId = 6, IsFree = true };

            Room room1Hotel7 = new Room() { Type = "Стнадарт двухместный", BedNum = 1, Prise = 5000, HotelId = 7, IsFree = true };
            Room room2Hotel7 = new Room() { Type = "Стнадарт трёхместный", BedNum = 2, Prise = 7500, HotelId = 7, IsFree = false };
            Room room3Hotel7 = new Room() { Type = "Люкс двухместный", BedNum = 1, Prise = 11000, HotelId = 7, IsFree = false };

            Room room1Hotel8 = new Room() { Type = "Стнадарт двухместный", BedNum = 1, Prise = 4000, HotelId = 8, IsFree = true };
            Room room2Hotel8 = new Room() { Type = "Стнадарт трёхместный", BedNum = 2, Prise = 6500, HotelId = 8, IsFree = true };
            Room room3Hotel8 = new Room() { Type = "Люкс двухместный", BedNum = 1, Prise = 10500, HotelId = 8, IsFree = true };

            Room room1Hotel9 = new Room() { Type = "Стнадарт двухместный", BedNum = 1, Prise = 2000, HotelId = 9, IsFree = false };
            Room room2Hotel9 = new Room() { Type = "Стнадарт трёхместный", BedNum = 2, Prise = 3500, HotelId = 9, IsFree = false };
            Room room3Hotel9 = new Room() { Type = "Люкс двухместный", BedNum = 1, Prise = 5500, HotelId = 9, IsFree = true };

            Room room1Hotel10 = new Room() { Type = "Стнадарт двухместный", BedNum = 1, Prise = 4000, HotelId = 10, IsFree = true };
            Room room2Hotel10 = new Room() { Type = "Стнадарт трёхместный", BedNum = 2, Prise = 6500, HotelId = 10, IsFree = true };
            Room room3Hotel10 = new Room() { Type = "Люкс двухместный", BedNum = 1, Prise = 8000, HotelId = 10, IsFree = true };

            context.Rooms.Add(room1Hotel1);
            context.Rooms.Add(room2Hotel1);
            context.Rooms.Add(room3Hotel1);
            context.Rooms.Add(room1Hotel2);
            context.Rooms.Add(room2Hotel2);
            context.Rooms.Add(room3Hotel2);
            context.Rooms.Add(room1Hotel3);
            context.Rooms.Add(room2Hotel3);
            context.Rooms.Add(room3Hotel3);
            context.Rooms.Add(room1Hotel4);
            context.Rooms.Add(room2Hotel4);
            context.Rooms.Add(room3Hotel4);
            context.Rooms.Add(room1Hotel5);
            context.Rooms.Add(room2Hotel5);
            context.Rooms.Add(room3Hotel5);
            context.Rooms.Add(room1Hotel6);
            context.Rooms.Add(room2Hotel6);
            context.Rooms.Add(room3Hotel6);
            context.Rooms.Add(room1Hotel7);
            context.Rooms.Add(room2Hotel7);
            context.Rooms.Add(room3Hotel7);
            context.Rooms.Add(room1Hotel8);
            context.Rooms.Add(room2Hotel8);
            context.Rooms.Add(room3Hotel8);
            context.Rooms.Add(room1Hotel9);
            context.Rooms.Add(room2Hotel9);
            context.Rooms.Add(room3Hotel9);
            context.Rooms.Add(room1Hotel10);
            context.Rooms.Add(room2Hotel10);
            context.Rooms.Add(room3Hotel10);
            context.SaveChanges();
        }
    }
}
