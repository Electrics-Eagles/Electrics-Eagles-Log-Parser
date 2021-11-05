#![cfg_attr(
  all(not(debug_assertions), target_os = "windows"),
  windows_subsystem = "windows"
)]

mod file_select;
mod parser;
use file_select::file_select;
use parser::parser;
use std::mem;
#[tauri::command]

fn get_selected(invoke_message: Vec<i32>) {
  unsafe {
  let _result=parser(",".to_string(),file_select().to_string());
  let mut _final_to_display:Vec<Vec<f32>>= Vec::new();
  for a in 0..invoke_message.len() {
    let f=&_result[invoke_message[a] as usize];
    _final_to_display.push(f.clone());


  }

println!("{:#?}",_final_to_display.len());
 
}

}





  
// Also in main.rs
fn main() {
  tauri::Builder::default()
    // This is where you pass in your commands
    .invoke_handler(tauri::generate_handler![get_selected])
    .run(tauri::generate_context!())
    .expect("failed to run app");
}
