using Microsoft.AspNetCore.Mvc;
using TextKeeper.Models;

namespace TextKeeper.Controllers
{
    public class FileController : Controller
    {

        private readonly string _stroagePath;
        public FileController(IConfiguration config)
        {
            _stroagePath = Path.Combine(Directory.GetCurrentDirectory(), config["FileStoragePath"]);
            if (Directory.Exists(_stroagePath))
            {
                Directory.CreateDirectory(_stroagePath);
            }
        }
        public IActionResult Index(string search)
        {
            var files = Directory.GetFiles(_stroagePath, "*.txt");
            var fileList = files.Select(f => Path.GetFileName(f)).ToList();

            if (!string.IsNullOrEmpty(search))
            {
                fileList = fileList
                           .Where(f => f.Contains(search, StringComparison.OrdinalIgnoreCase))
                           .ToList();

            }
            return View(fileList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TextFile model)
        {
            var filePath = Path.Combine(_stroagePath, model.FileName + ".txt");
            System.IO.File.WriteAllText(filePath, model.Content);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(string fileName)
        {
            var filePath = Path.Combine(_stroagePath, fileName);
            var content = System.IO.File.ReadAllText(filePath);

            var model = new TextFile { FileName = Path.GetFileNameWithoutExtension(fileName),Content = content };
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(TextFile model)
        {
            var filePath =  Path.Combine(_stroagePath,model.FileName+".txt");
            System.IO.File.WriteAllText(filePath,model.Content);
            return RedirectToAction("Index");
        }
    }
}
