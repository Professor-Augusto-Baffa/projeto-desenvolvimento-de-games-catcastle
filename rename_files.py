import os

def convert_to_snake_case(filename):
    """Convert a given filename from PascalCase or camelCase to snake_case."""
    if filename.islower() or filename.isupper():  # Check if the filename is already in a single case
        return filename
    snake_case_name = ''
    for index, char in enumerate(filename):
        if char.isupper() and index != 0:
            snake_case_name += '_'
        snake_case_name += char.lower()
    return snake_case_name

def rename_files_recursive(directory):
    """Rename all files in the specified directory and its subdirectories from PascalCase/camelCase to snake_case."""
    for root, dirs, files in os.walk(directory):
        for filename in files:
            new_name = convert_to_snake_case(filename)
            if new_name != filename:  # Rename the file only if the new name is different
                os.rename(os.path.join(root, filename), os.path.join(root, new_name))
                print(f"Renamed {filename} to {new_name}")
                
rename_files_recursive(os.getcwd())