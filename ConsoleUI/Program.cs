﻿using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;

//ProductManager productManager = new ProductManager(new EfProductDal());
//foreach (var product in productManager.GetByUnitPrice(50,100)) {
//    Console.WriteLine(product.ProductName);
//} 


CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
foreach (var category in categoryManager.GetAll()) 
{
    Console.WriteLine(category.CategoryName);
}
Console.ReadLine();