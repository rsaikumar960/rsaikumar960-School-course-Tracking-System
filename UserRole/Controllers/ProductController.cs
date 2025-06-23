using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using UserRoles.Helper;
using UserRoles.Models;

namespace UserRoles.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }
        [Authorize]
        public IActionResult Index(string name, string @class, string section, string grade)
        {
            var students = _context.products.AsQueryable();

            if (!string.IsNullOrWhiteSpace(name))
                students = students.Where(s => s.Name.Contains(name));

            if (!string.IsNullOrWhiteSpace(@class))
                students = students.Where(s => s.Class.Contains(@class));

            if (!string.IsNullOrWhiteSpace(section))
                students = students.Where(s => s.Section.Contains(section));

            return View(students.ToList());
        }



        [Authorize]
        public IActionResult Content(string name, string @class, string section, string grade)
        {
            var students = _context.products.AsQueryable();

            if (!string.IsNullOrWhiteSpace(name))
                students = students.Where(s => s.Name.Contains(name));

            if (!string.IsNullOrWhiteSpace(@class))
                students = students.Where(s => s.Class.Contains(@class));

            if (!string.IsNullOrWhiteSpace(section))
                students = students.Where(s => s.Section.Contains(section));

            return View(students.ToList());
        }

        [Authorize]
        public IActionResult StudentContent(string name, string @class, string section, string grade)
        {
            var students = _context.products.AsQueryable();

            if (!string.IsNullOrWhiteSpace(name))
                students = students.Where(s => s.Name.Contains(name));

            if (!string.IsNullOrWhiteSpace(@class))
                students = students.Where(s => s.Class.Contains(@class));

            if (!string.IsNullOrWhiteSpace(section))
                students = students.Where(s => s.Section.Contains(section));

            return View(students.ToList());
        }



        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product productDto )
        {


            if (productDto != null)
            {
                var product = new Product
                {
                    Name = productDto.Name,
                    Class = productDto.Class,
                    Section = productDto.Section,
                    StudentId = productDto.StudentId,
                    Mars = productDto.Mars
                };
                ViewData["ProductName"] = productDto.Name;
                _context.products.Add(product);
                _context.SaveChanges();
                return View(productDto);
            }

            return RedirectToAction("Content", "product");
        }


        public IActionResult CreateContent()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateContent(Product productDto)
        {


            if (productDto != null)
            {
                var product = new Product
                {
                    Section=productDto.Section,
                  
                    
                };
                ViewData["ProductName"] = productDto.Name;
                _context.products.Add(product);
                _context.SaveChanges();
                return View(productDto);
            }

            return RedirectToAction("Content", "product");
        }







        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = _context.products.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            var productDto = new ProductDto
            {
                Name = product.Name,
                Class = product.Class,
                Section = product.Section,
              
                Mars = product.Mars
            };

            return View(productDto);
        }


        [HttpPost]
        public IActionResult Edit(int id, ProductDto productDto)
        {
            if (productDto == null)
            {
                return RedirectToAction("Index", "Product");
            }

            var existingProduct = _context.products.Find(id);
            if (existingProduct == null)
            {
                return NotFound();
            }


            existingProduct.Name = productDto.Name;
            existingProduct.Class = productDto.Class;
            existingProduct.Section = productDto.Section;
           
            existingProduct.Mars = productDto.Mars;

            _context.products.Update(existingProduct);
            _context.SaveChanges();

            return RedirectToAction("Index", "Product");
        }


        //[HttpGet]
        //public IActionResult EditContent(int id)
        //{
        //    var product = _context.products.Find(id);
        //    if (product == null)
        //    {
        //        return NotFound();
        //    }

        //    var productDto = new Product
        //    {

        //        Section = product.Section,

        //        description = product.description,
                
               
        //    };

        //    return View(productDto);
        //}


        //[HttpPost]
        //public IActionResult EditContent(int id, Product productDto)
        //{
        //    if (productDto == null)
        //    {
        //        return RedirectToAction("content", "Product");
        //    }

        //    var existingProduct = _context.products.Find(id);
        //    if (existingProduct == null)
        //    {
        //        return NotFound();
        //    }


        //    existingProduct.Section = productDto.Section;
        //    existingProduct.description = productDto.description;
            

        //    _context.products.Update(existingProduct);
        //    _context.SaveChanges();

        //    return RedirectToAction("Content", "Product");
        //}













        public IActionResult Delete(int id)
        {
            var product = _context.products.Find(id);
            if (product != null)
            {
                _context.products.Remove(product);
                _context.SaveChanges(true);
                return RedirectToAction("Index", "Product");
            }
            else
            {
                return NotFound(product.Name);
            }
        }

    }
}
