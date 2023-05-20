using SAYUFOOD.Models.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.CodeDom;

namespace SAYUFOOD.Models
{
    public class ShoppingCartItem
    {
        public Product Shopping_Product { get; set; }
        public int Shopping_Quantity { get; set; }

        //public double Shopping_Total { get; set; }

    }
    // Gio hang 
    public class ShoppingCart
    {
        List<ShoppingCartItem> items = new List<ShoppingCartItem>();

        public IEnumerable<ShoppingCartItem> Items
        {
            get { return items; }
        }
        public void Add(Product _pro, int quantity = 1)
        {
            var item = items.FirstOrDefault(x=> x.Shopping_Product.Id == _pro.Id);
            if(item == null)
            {
                items.Add(new ShoppingCartItem
                {
                    Shopping_Product = _pro,
                    Shopping_Quantity = quantity

                }); 
            }
            else
            {
                item.Shopping_Quantity += quantity;
            }
        }


        public void Update_quantity(int id, int quantity)
        {
            var item = items.Find(x => x.Shopping_Product.Id == id);
            if(item != null)
            {
                item.Shopping_Quantity = quantity;
            }
        }

        public double Total_money()
        {
            var total = items.Sum(x => x.Shopping_Product.Price * x.Shopping_Quantity);
            return (double)total;
        }

        public void Remove_CartItem(int id)
        {
            items.RemoveAll(x => x.Shopping_Product.Id == id);
        }

        

        
    }
        

 }