//using AspDotNetCoreMVCProject.Data;
using AspDotNetCoreMVCProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AspDotNetCoreMVCProject.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductInventoryDbContext _context;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(ProductInventoryDbContext context, ILogger<ProductsController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // =========================================================
        // GET: Products
        // =========================================================

        public async Task<IActionResult> Index(string? search)
        {
            try
            {
                ViewBag.Search = search;

                    var products = _context.Products
                        .Include(p => p.Category)
                        .AsNoTracking()
                        .AsQueryable();

                    if (!string.IsNullOrWhiteSpace(search))
                    {
                        products = products.Where(p =>
                            p.ProductName.Contains(search) ||
                            (p.SupplierName != null &&
                             p.SupplierName.Contains(search)) ||
                            p.Category.CategoryName.Contains(search));
                    }

                    var result = await products
                        .OrderByDescending(p => p.ProductId)
                        .ToListAsync();

                    return View(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Error occurred while loading products.");

                return View("Error");
            }
        }


        // =========================================================
        // GET: Products/Details/5
        // =========================================================

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var product = await _context.Products
                .Include(p => p.Category)
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.ProductId == id);

            if (product == null)
                return NotFound();

            return View(product);
        }


        // =========================================================
        // GET: Products/Create
        // =========================================================

        public async Task<IActionResult> Create()
        {
            await LoadCategories();

            return View();
        }


        // =========================================================
        // POST: Products/Create
        // =========================================================

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            // Navigation property should not be validated
            ModelState.Remove("Category");

            if (!ModelState.IsValid)
            {
                await LoadCategories(product.CategoryId);

                return View(product);
            }

            product.CreatedDate = DateTime.Now;

            _context.Products.Add(product);

            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] =
                "Product created successfully.";

            return RedirectToAction(nameof(Index));
        }


        // =========================================================
        // GET: Products/Edit/5
        // =========================================================

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var product = await _context.Products
                .FindAsync(id);

            if (product == null)
                return NotFound();

            await LoadCategories(product.CategoryId);

            return View(product);
        }


        // =========================================================
        // POST: Products/Edit/5
        // =========================================================

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
            int id,
            Product product)
        {
            if (id != product.ProductId)
                return NotFound();

            ModelState.Remove("Category");

            if (!ModelState.IsValid)
            {
                await LoadCategories(product.CategoryId);

                return View(product);
            }

            try
            {
                var existingProduct =
                    await _context.Products.FindAsync(id);

                if (existingProduct == null)
                    return NotFound();

                existingProduct.ProductName =
                    product.ProductName;

                existingProduct.CategoryId =
                    product.CategoryId;

                existingProduct.Price =
                    product.Price;

                existingProduct.Quantity =
                    product.Quantity;

                existingProduct.SupplierName =
                    product.SupplierName;

                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] =
                    "Product updated successfully.";

                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(product.ProductId))
                    return NotFound();

                throw;
            }
        }


        // =========================================================
        // GET: Products/Delete/5
        // =========================================================

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var product = await _context.Products
                .Include(p => p.Category)
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.ProductId == id);

            if (product == null)
                return NotFound();

            return View(product);
        }


        // =========================================================
        // POST: Products/Delete/5
        // =========================================================

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products
                .FindAsync(id);

            if (product != null)
            {
                _context.Products.Remove(product);

                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] =
                    "Product deleted successfully.";
            }

            return RedirectToAction(nameof(Index));
        }


        // =========================================================
        // Helper: Load Categories
        // =========================================================

        private async Task LoadCategories(int? selectedCategoryId = null)
        {
            var categories = await _context.Categories
                .AsNoTracking()
                .OrderBy(c => c.CategoryName)
                .ToListAsync();

            ViewBag.CategoryId = new SelectList(
                categories,
                "CategoryId",
                "CategoryName",
                selectedCategoryId);
        }


        // =========================================================
        // Product Exists
        // =========================================================

        private bool ProductExists(int id)
        {
            return _context.Products
                .Any(p => p.ProductId == id);
        }
    }
}