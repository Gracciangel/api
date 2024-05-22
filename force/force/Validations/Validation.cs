using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions ;
namespace force.Validations
{
   public class Validation
    {
    private readonly Regex regex = new Regex( @"^[a-zA-Z0-9_\-]*$");
    private readonly Regex regexName = new Regex(@"^[a-zA-Z]+$") ;

    private readonly Regex regexDoc = new Regex(@"^[0-9]+$") ;
        public bool ValidateNick (string data) {

            if((data.Length < 5|| data.Length > 10) && regex.IsMatch(data) ){
                Console.WriteLine("validando el nick...");
                return true ;
            }
            else {

            return false;  
            }
        }

        public bool ValidateName(string data , int min , int max){

            if((data.Length < min && data.Length > max ) &&  regexName.IsMatch(data))
            {
                Console.WriteLine("Validando " + data+ " retornando true") ;
                return false;
            }
            else 
            {
                Console.WriteLine("Validando el " + data + " retornando false") ;
                return true; 
            }
        }
        public bool ValidateString (string data , int min , int max ){

            if(data.Length < min || data.Length > max ){
                Console.WriteLine("Validando el String " + data) ;
                return true ;
            }else {

            return false;  
            }
        }
        public bool ValidateEdad(int edad){
            if(edad <  6 || edad >= 14 ){
                Console.WriteLine("estoy validando la edad") ;
                return true ; 
            }else{
                Console.WriteLine(" el retorno de validateEdad es true") ; 
                return false; 
            }
        }
        public bool ValidateDoc(string data){
            
            if((data.Length < 8 || data.Length > 11 ) &&  regexDoc.IsMatch(data))
            {
                Console.WriteLine(" estoy validando el documento") ;
                return false ;
            }
            else 
            {
                Console.Write(" el retorno de validateDoc es true") ;
                return true ; 
            }
        }
    }
}