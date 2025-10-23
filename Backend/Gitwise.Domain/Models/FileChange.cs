namespace Gitwise.Domain.Models;

public class FileChange(
    string fileSnapshotSha,
    string fileName,
    ChangeStats changeStats,
    string changeDefinition,
    FileSnapshot? fileSnapshot)
{
    public string FileSnapshotSha { get; } = fileSnapshotSha;
    public string FileName { get; } = fileName;
    public ChangeStats ChangeStats { get; } = changeStats;
    public string ChangeDefinition { get; } = changeDefinition;
    public FileSnapshot? FileSnapshot { get; set; } = fileSnapshot;
}
