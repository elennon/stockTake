using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Models
{
    public class StockTake
    {
        public StockTake()
        {
        }

        public StockTake(List<string> bk, List<Items> itms)
        {
            barecodeNumber = bk;
            items = itms;
        }
        public List<string> barecodeNumber {  get; set; }
        public List<Items> items { get; set; }

        public List<Items> SeedItems()
        {
            List<Items> its = new List<Items>();
            for (int i = 0; i < 20;i++) 
            {
                its.Add(new Items("item number " + i.ToString(), 0));
            }
            return its; 
        }

    }
    public class Items : INotifyPropertyChanged 
    {
        public Items(string nme, int nmb) 
        {
            ItemName = nme;
            ItemNumber = nmb;
        }
        public Items() { }
        private int _age;
        public string ItemName { get; set; }
        public int ItemNumber {
            get => _age;
            set
            {
                _age = value;
                RaisePropertyChanged(nameof(ItemNumber));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
