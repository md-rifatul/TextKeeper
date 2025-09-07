using Microsoft.AspNetCore.Mvc;
using TextKeeper.Models;

namespace TextKeeper.Controllers
{
    public class FileController : Controller
    {

        private readonly string _stroagePath;
        private readonly string _backupPath;
        public FileController(IConfiguration config)
        {
            _stroagePath = Path.Combine(Directory.GetCurrentDirectory(), config["FileStoragePath"]);
            _backupPath = Path.Combine(Directory.GetCurrentDirectory(), config["BackupStoregePath"]);

            if (!Directory.Exists(_stroagePath))
            {
                Directory.CreateDirectory(_stroagePath);
            }
            if (!Directory.Exists(_backupPath))
            {
                Directory.CreateDirectory(_backupPath);
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

            var model = new TextFile
            {
                FileName = fileName,
                Content = content
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(TextFile model)
        {
            var filePath = Path.Combine(_stroagePath, model.FileName);
            System.IO.File.WriteAllText(filePath, model.Content);
            return RedirectToAction("Index");
        }


        public IActionResult Delete(string fileName)
        {
            var filePath = Path.Combine(_stroagePath,fileName);
            var backupFilePath = Path.Combine(_backupPath,fileName);
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Move(filePath, backupFilePath,overwrite:true);
                System.IO.File.Delete(filePath);
            }
            return RedirectToAction("Index");
        }

        public IActionResult BackUp(string search)
        {
            var files = Directory.GetFiles(_backupPath, "*.txt");
            var fileList = files.Select(f => Path.GetFileName(f)).ToList();

            if (!string.IsNullOrEmpty(search))
            {
                fileList = fileList
                           .Where(f => f.Contains(search, StringComparison.OrdinalIgnoreCase))
                           .ToList();

            }
            return View(fileList);
        }
        public IActionResult PermanentDelete(string fileName)
        {
            
            var backupFilePath = Path.Combine(_backupPath, fileName);
            if (System.IO.File.Exists(backupFilePath))
            {
                System.IO.File.Delete(backupFilePath);
            }
            return RedirectToAction("Backup");
        }
    }
}
