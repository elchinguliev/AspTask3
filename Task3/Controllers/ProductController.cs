using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Task3.Services;
using Task3.Models;
using Task3.Entities;
using System.Linq;

namespace Task3.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var vm = new ProductViewModel
            {
                Products = await _productService.GetAllByKey()
            };
            return View("ProductIndex", vm);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int myid)
        {
            var prodList = await _productService.GetAllByKey();
            var prod = prodList.SingleOrDefault(p => p.Id == myid);
            var vm = new ProductUpdateViewModel
            {
                Product = prod,
            };
            return View(vm);
        }

        [HttpPost]
        public IActionResult Update(ProductUpdateViewModel vm)
        {
            _productService.Update(vm.Product);
            return RedirectToAction("index");
        }

        [HttpGet]
        public IActionResult Add()
        {
            var vm = new ProductAddViewModel
            {
                Product = new Product(),
            };
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductAddViewModel vm)
        {
            await _productService.Add(vm.Product);
            return RedirectToAction("index");

        }

        public async Task<IActionResult> Delete(int myid)
        {
            var prodList = await _productService.GetAllByKey();
            var prod = prodList.SingleOrDefault(p => p.Id == myid);
            _productService.Delete(prod);
            return RedirectToAction("index");
        }
    }
}
