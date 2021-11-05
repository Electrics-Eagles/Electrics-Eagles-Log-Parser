use std::fs::File;
use std::io::{self, BufRead};
use std::path::Path;

fn read_lines<P>(filename: P) -> io::Result<io::Lines<io::BufReader<File>>>
where
  P: AsRef<Path>,
{
  let file = File::open(filename)?;
  Ok(io::BufReader::new(file).lines())
}
/*
Error handler .. counts error
*/

pub fn error_counter(error: usize, mut counter: &mut usize) {
  if error == 12 {
    *counter = *counter + 1
  }
}
/*
Correct parse handler 
&mut Vec<Vec<f32>>,
*/
pub fn add_to_list_vectors(list_of_vectors: &mut Vec<Vec<f32>>, counter: usize, n: f32) {
  list_of_vectors[counter].push(n);
}
/* parse code */
pub fn parser(delimeter: String, path: String) -> Vec<Vec<f32>> {
  let mut list_of_vectors: Vec<Vec<f32>> = Vec::new();
  let mut error_counter_var: usize = 0;
  for a in 0..28 {
    list_of_vectors.push(Vec::new());
  }

  if let Ok(lines) = read_lines(path) {
    // Consumes the iterator, returns an (Optional) String
    for line in lines {
      if let Ok(now_line_parsed) = line {
        let mut split = now_line_parsed.split(",");
        let mut counter: usize = 0;
        for s in split {
          // or, to be safe, match the `Err`
          match s.parse::<f32>() {
            Ok(n) => add_to_list_vectors(&mut list_of_vectors, counter, n),
            Err(e) => error_counter(12, &mut error_counter_var),
          }
          counter = counter + 1;
        }
      }
    }
    println!("Errors recogised: {}", error_counter_var)
  }
  return list_of_vectors;
}
