using System;
using System.Text;

namespace Memento.RealWorld
{
 
    // The 'Originator' class
   
    class FlowersShopSales
    {
        private string _name;
        private string _quantity;
        private double _price;

        // Gets or sets name
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                Console.WriteLine("Име:  " + _name);
            }
        }

        // Gets or sets quantity
        public string Quantity
        {
            get { return _quantity; }
            set
            {
                _quantity = value;
                Console.WriteLine("Количество: " + _quantity);
            }
        }

        // Gets or sets price
        public double Price
        {
            get { return _price; }
            set
            {
                _price = value;
                Console.WriteLine("Цена: " + _price);
            }
        }

        // Stores memento
        public Memento SaveMemento()
        {
            Console.WriteLine("\nЗапазване на състояние... --\n");
            return new Memento(_name, _quantity, _price);
        }

        // Restores memento
        public void RestoreMemento(Memento memento)
        {
            Console.WriteLine("\nВръщане на състоянието... --\n");
            this.Name = memento.Name;
            this.Quantity = memento.Quantity;
            this.Price = memento.Price;
        }
    }


    // The 'Memento' class
 
    class Memento
    {
        private string _name;
        private string _quantity;
        private double _price;

        // Constructor
        public Memento(string name, string quantity, double price)
        {
            this._name = name;
            this._quantity = quantity;
            this._price = price;
        }

        // Gets or sets name
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        // Gets or sets quantity
        public string Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }

        // Gets or sets price
        public double Price
        {
            get { return _price; }
            set { _price = value; }
        }
    }

    
    // The'Caretaker'  class
    
    class FlowersShopMemory
    {
        private Memento _memento;

        // Пропъртита
        public Memento Memento
        {
            set { _memento = value; }
            get { return _memento; }
        }
    }
    class MainApp
    {
        
        // Entrance in the console application
     
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            FlowersShopSales s = new FlowersShopSales();
            s.Name = "Нарциси";
            s.Quantity = "10 броя";
            s.Price = 25.00;

            // Saves the internal state
            FlowersShopMemory m = new FlowersShopMemory();
            m.Memento = s.SaveMemento();

            // Continues changing the originator
            s.Name = "Карамфили";
            s.Quantity = "15 броя";
            s.Price = 30.0;

            // Restores saved state
            s.RestoreMemento(m.Memento);

            // Wait the user
            Console.ReadKey();
        }
    }


}

