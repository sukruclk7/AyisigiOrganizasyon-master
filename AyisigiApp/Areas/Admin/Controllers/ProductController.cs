using Entities.Dtos;
using Entities.Models;
using Entities.RequestParameters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Services.Contracts;
using AyisigiApp.Models;

namespace AyisigiApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ProductController : Controller
    {
        private readonly IServiceManager _manager;

        public ProductController(IServiceManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index([FromQuery] ProductRequestParameters p)
        {
            ViewData["Title"] = "Ürünler";

            var products = _manager.ProductService.GetAllProductsWithDetails(p);
            var pagination = new Pagination()
            {
                CurrenPage = p.PageNumber,
                ItemsPerPage = p.PageSize,
                TotalItems = _manager.ProductService.GetAllProducts(false).Count()
            };

            return View(new ProductListViewModel()
            {
                Products = products,
                Pagination = pagination
            });
        }

        public IActionResult Create()
        {
            TempData["info"] = "Formu doldurun lütfen.";
            ViewBag.Categories = GetCategoriesSelectList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] ProductDtoForInsertion productDto, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", file.FileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                productDto.ImageUrl = $"/images/{file.FileName}";
                _manager.ProductService.CreateProduct(productDto);

                TempData["success"] = $"{productDto.ProductName} oluşturuldu.";
                return RedirectToAction("Index");
            }

            ViewBag.Categories = GetCategoriesSelectList();
            return View(productDto);
        }

        private SelectList GetCategoriesSelectList()
        {
            return new SelectList(
                _manager.CategoryService.GetAllCategories(false),
                "CategoryId",
                "CategoryName",
                "1"
            );
        }

        public IActionResult Update([FromRoute(Name = "id")] int id)
        {
            ViewBag.Categories = GetCategoriesSelectList();
            var model = _manager.ProductService.GetOneProductForUpdate(id, false);
            ViewData["Title"] = model?.ProductName;
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update([FromForm] ProductDtoForUpdate productDto, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                // Yeni resim yüklendiyse değiştir
                if (file != null && file.Length > 0)
                {
                    string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", file.FileName);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                    productDto.ImageUrl = $"/images/{file.FileName}";
                }
                // Yeni resim seçilmezse → productDto.ImageUrl zaten eski resmi içeriyor

                _manager.ProductService.UpdateOneProduct(productDto);

                TempData["success"] = "Ürün güncellendi.";
                return RedirectToAction("Index");
            }

            ViewBag.Categories = GetCategoriesSelectList();
            return View(productDto);
        }


        [HttpGet]
        public IActionResult Delete([FromRoute(Name = "id")] int id)
        {
            _manager.ProductService.DeleteOneProduct(id);
            TempData["danger"] = "Ürün kaldırıldı.";
            return RedirectToAction("Index");
        }
    }
}
