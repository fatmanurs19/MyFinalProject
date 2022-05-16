using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;

//ProductManager productManager = new ProductManager(new EfProductDal());
//foreach (var product in productManager.GetByUnitPrice(50,100)) {
//   Console.WriteLine(product.ProductName);
//} 


//CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
//foreach (var category in categoryManager.GetAll()) 
//{
//    Console.WriteLine(category.CategoryName);
//}

ProductManager productManager = new ProductManager(new EfProductDal());
var result = productManager.GetProductDetails();
if (result.Success == true)
{
    foreach (var product in result.Data)
    {
        Console.WriteLine(product.ProductName + "/" + product.CategoryName);
    }
}
else
{
    Console.WriteLine(result.Message);
}




