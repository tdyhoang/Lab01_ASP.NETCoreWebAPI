﻿using BusinessObjects;
using Microsoft.EntityFrameworkCore;

public class ProductDAO
{
    public static List<Product> GetProducts()
    {
        var listProducts = new List<Product>();
        try
        {
            using (var context = new MyDbContext())
            {
                listProducts = context.Products.ToList();
            }
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }

        return listProducts;
    }

    public static Product FindProductById(int prodId)
    {
        var p = new Product();
        try
        {
            using (var context = new MyDbContext())
            {
                p = context.Products.SingleOrDefault(x => x.ProductId == prodId);
            }
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }

        return p;
    }

    public static void SaveProduct(Product p)
    {
        try
        {
            using (var context = new MyDbContext())
            {
                context.Products.Add(p);
                context.SaveChanges();
            }
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public static void UpdateProduct(Product p)
    {
        try
        {
            using (var context = new MyDbContext())
            {
                context.Entry(p).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public static void DeleteProduct(Product p)
    {
        try
        {
            using (var context = new MyDbContext())
            {
                var p1 = context.Products.SingleOrDefault(c => c.ProductId == p.ProductId);
                context.Products.Remove(p1);
                context.SaveChanges();
            }
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}