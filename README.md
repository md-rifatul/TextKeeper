# 📂 TextKeeper

**TextKeeper** is a simple ASP.NET Core MVC application that works as a **file manager** for `.txt` files.  
It allows you to **create, edit, view, delete, restore, and manage text files** with a built-in recycle bin feature.

---

## 🚀 Features

- **Create Files**: Add new `.txt` files with custom content.
- **Edit Files**: Update the content of existing files.
- **View Files**: Open files in read-only mode with a clean editor-style view.
- **Delete Files**: Soft delete (moves files to the recycle bin).
- **Recycle Bin (Backup)**:
  - Restore files back to storage.
  - Permanently delete files from recycle bin.
- **Search**: Search files by name in both storage and recycle bin.
- **File Storage Paths**:
  - Active files are stored in `FileStoragePath`.
  - Deleted files are stored in `BackupStoregePath`.

---

## 🛠 Technologies Used

- **ASP.NET Core MVC**
- **C#**
- **Razor Views**
- **Tailwind CSS** (for UI design)
- **System.IO** (for file operations)

---

## 📂 Project Structure

```

TextKeeper/
│── Controllers/
│   ├── FileController.cs      # Main controller for file operations
│   └── HomeController.cs
│
│── Models/
│   ├── TextFile.cs            # Model for file name + content
│   └── ErrorViewModel.cs
│
│── Views/
│   ├── File/
│   │   ├── Backup.cshtml      # Recycle bin (deleted files)
│   │   ├── Create.cshtml      # Create new file
│   │   ├── Edit.cshtml        # Edit file
│   │   ├── FileView\.cshtml    # View file content
│   │   └── Index.cshtml       # File list
│   ├── Home/
│   └── Shared/
│
│── TextFiles/                 # Storage directory for .txt files
│── appsettings.json           # Configuration for file paths
│── Program.cs                 # Entry point

````

---

## ⚙️ Setup Instructions

1. **Clone the repository**:
   ```bash
   git clone https://github.com/your-username/TextKeeper.git
   cd TextKeeper
````

2. **Configure storage paths** in `appsettings.json`:

   ```json
   {
     "FileStoragePath": "TextFiles",
     "BackupStoregePath": "BackupFiles"
   }
   ```

3. **Run the project**:

   ```bash
   dotnet run
   ```

4. **Access in browser**:

   ```
   https://localhost:5001/File
   ```

---

## 🎯 Usage

* Navigate to **File Manager** (`/File/Index`) to see all files.
* Use **Create** to make a new text file.
* Use **Edit** to modify file content.
* Use **Delete** to move files to recycle bin.
* Go to **Recycle Bin** (`/File/Backup`) to restore or permanently delete files.
* Use **FileView** to read file contents without editing.

---

## 📌 Future Improvements

* Syntax highlighting in editor.
* Support for multiple file types.
* Drag & drop file upload.
* Download button in FileView.
* User authentication (to restrict access).

---

## 👨‍💻 Author

Developed by **Rifatul Islam** as a practice project for learning **ASP.NET Core MVC** file handling and CRUD operations.
