import os

def convert_to_pascal_case(filename):
    """Convert a given filename from snake_case to PascalCase."""
    parts = filename.split('_')
    pascal_case_name = ''.join(part.capitalize() for part in parts)
    return pascal_case_name

def rename_files_recursive(directory):
    """Rename all files in the specified directory and its subdirectories from snake_case to PascalCase."""
    for root, dirs, files in os.walk(directory):
        for filename in files:
            new_name = convert_to_pascal_case(filename)
            if new_name != filename:  # Rename the file only if the new name is different
                os.rename(os.path.join(root, filename), os.path.join(root, new_name))
                print(f"Renamed {filename} to {new_name}")

# Exemplo de uso:
rename_files_recursive(os.getcwd()) 