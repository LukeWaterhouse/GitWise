using SummaryEngine.Domain.Interfaces.Domain;
using SummaryEngine.Domain.Models;

namespace SummaryEngine.Domain.Services;

public class FileChangeFilterService : IFileChangeFilterService
{
    private const int ConditionalMaxFileContentLength = 8000;
    private const int ConditionalMaxChangeDiffLength = 3000;
    private static readonly HashSet<string> ConditionalIgnoreExtensions = new(StringComparer.OrdinalIgnoreCase)
    {
        ".md", ".lock", ".csv", ".svg", ".map", ".min.js",
        ".bundle.js", ".js", ".tsbuildinfo", ".cache", ".xml", 
        ".yml", ".yaml", ".config"
    };
    
    private const int HardCapFileContentLength = 16000;
    private const int HardCapChangeDiffLength = 10000;
    private static readonly HashSet<string> AlwaysIgnoreExtensions = new(StringComparer.OrdinalIgnoreCase)
    {
        // 🖼️ Images & graphics
        ".png", ".jpg", ".jpeg", ".gif", ".bmp", ".ico", ".tiff", ".webp", ".heic", ".svgz",

        // 🎥 Video & animation
        ".mp4", ".mov", ".avi", ".mkv", ".webm", ".flv", ".wmv",

        // 🎵 Audio
        ".mp3", ".wav", ".ogg", ".flac", ".aac", ".m4a",

        // 🗜️ Archives & compression
        ".zip", ".rar", ".tar", ".gz", ".bz2", ".7z", ".xz",

        // ⚙️ Binaries & compiled outputs
        ".dll", ".exe", ".pdb", ".so", ".dylib", ".obj", ".lib", ".class", ".jar", ".war", ".apk", ".ipa",

        // 💾 Disk & data dumps
        ".iso", ".img", ".bin", ".dat", ".db", ".sqlite", ".mdb",

        // 🧩 Fonts
        ".ttf", ".otf", ".woff", ".woff2", ".eot",

        // 🧠 3D / design / CAD files
        ".fbx", ".blend", ".3ds", ".dae", ".stl", ".obj", ".mtl",

        // 🧱 Design / vector / project binaries
        ".psd", ".ai", ".xd", ".fig", ".sketch",
        
        // 🧬 Miscellaneous generated or machine-only data
        ".lockb", ".binlog", ".nupkg", ".crx", ".pak", ".wasm", ".pem", ".crt", ".key", ".cer", ".pfx", ".DS_Store"
    };
    
    public Dictionary<string, List<Commit>> FilterFileChangesForSummarization(
        Dictionary<string, List<Commit>> repositoryCommits)
    {
        foreach (var (_, commits) in repositoryCommits)
        {
            Parallel.ForEach(commits, commit =>
            {
                foreach (var fileChange in commit.FileChanges)
                {
                    if (!ShouldIncludeFileSnapshot(fileChange))
                    {
                        fileChange.FileSnapshot = null;
                    }

                    if (!ShouldIncludeChangeDefinition(fileChange))
                    {
                        fileChange.ChangeDefinition = null;
                    }
                }
            });
        }

        return repositoryCommits;
    }
    
    private static bool ShouldIncludeFileSnapshot(FileChange fileChange)
    {
        if (fileChange.FileSnapshot?.DecodedContent is null)
        {
            return false;
        }
        
        var extension = Path.GetExtension(fileChange.FileName);
        if (AlwaysIgnoreExtensions.Contains(extension))
        {
            return false;
        }

        if (fileChange.FileSnapshot.DecodedContent.Length > HardCapFileContentLength)
        {
            return false;
        }

        if (ConditionalIgnoreExtensions.Contains(extension) &&
            fileChange.FileSnapshot?.DecodedContent.Length > ConditionalMaxFileContentLength)
        {
            return false;
        }

        return true;
    }

    private static bool ShouldIncludeChangeDefinition(FileChange fileChange)
    {
        if (fileChange.ChangeDefinition is null)
        {
            return false;
        }
        
        var extension = Path.GetExtension(fileChange.FileName);

        if (AlwaysIgnoreExtensions.Contains(extension))
        {
            return false;
        }

        if (fileChange.ChangeDefinition.Length > HardCapChangeDiffLength)
        {
            return false;
        }

        if (ConditionalIgnoreExtensions.Contains(extension) &&
            fileChange.ChangeDefinition?.Length > ConditionalMaxChangeDiffLength)
        {
            return false;
        }
        
        return true;
    }
}