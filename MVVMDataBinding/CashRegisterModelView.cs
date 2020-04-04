using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using CashRegister;

namespace MVVMDataBinding
{
    public class CashRegisterModelView : INotifyPropertyChanged
    {
        /// <summary>
        /// Notifies of property changed
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// The CashDrawer this class uses
        /// </summary>
        CashDrawer drawer = new CashDrawer();

        /// <summary>
        /// thet total current value of the drawer
        /// </summary>
        public double TotalValue => drawer.TotalValue;

        public int Pennies
        {
            get => drawer.Pennies;

            set
            {
                if (drawer.Pennies == value || value < 0) return;
                var quantity = value - drawer.Pennies;
                if(quantity > 0)
                {
                    drawer.AddCoin(Coins.Penny, quantity);
                }
                else
                {
                    drawer.RemoveCoin(Coins.Penny, -quantity);
                }
                InvokePropertyChanged("Pennies");
            }
        }

        public int Nickles
        {
            get => drawer.Nickles;

            set
            {
                if (drawer.Nickles == value || value < 0) return;
                var quantity = value - drawer.Nickles;
                if(quantity > 0)
                {
                    drawer.AddCoin(Coins.Nickle, quantity);
                }
                else
                {
                    drawer.RemoveCoin(Coins.Nickle, -quantity);
                }
                InvokePropertyChanged("Nickles");
            }
        }
        //dimes
        //quarters
        //halfdollars
        //Dollars
        //ones
        //twos
        //fives
        //tens
        //twenties
        //fiftties
        //hundreds

        void InvokePropertyChanged(string denomination)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(denomination));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TotalValue"));
        }
    }
}
