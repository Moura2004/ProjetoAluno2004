using System;
using ProjetoAluno2021.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace ProjetoAluno2021.Controllers
{
     public class AlunoController : Controller{

          //Listar
           public IActionResult Lista(){


           AlunoRepository ur =new AlunoRepository();
            List<Aluno> Listagem= ur.listar();
             return View(Listagem);
           }

         //Remover
           public IActionResult Remover(int id){
              
              AlunoRepository ur=new AlunoRepository();
              Aluno user= ur.buscarPorid(id);
              ur.remover(user);
              
               return  RedirectToAction("Lista");
           }

         //Editar
         public IActionResult Editar(int id){
           AlunoRepository ur = new AlunoRepository();
            Aluno user = ur.buscarPorid(id);
             return View(user);
         }


         //Editar- grava no banco
          [HttpPost]
           public IActionResult Editar(Aluno userForm){
            AlunoRepository ur=new AlunoRepository();
            ur.atualizar(userForm);
            return RedirectToAction("Lista");


           }




         //Cadastro
          public IActionResult Cadastro(){
            return View();
          }


         //Cadastro- grava no banco
           
           [HttpPost]
           public IActionResult Cadastro(Aluno userForm){

           AlunoRepository ur= new AlunoRepository();
            ur.inserir(userForm);
             ViewBag.Mesagem= "Cadastro realiado com sucesso";
             return View();
           }



        }
          }
