use rfd::FileDialog;

pub fn file_select() -> String {
  let files = FileDialog::new()
    .add_filter("logs", &["log", "txt"])
    .set_directory("/")
    .pick_file(); // get file path in pathbuf
  let path_string = files.unwrap().into_os_string().into_string().unwrap(); // convert to string
  return path_string;
}
