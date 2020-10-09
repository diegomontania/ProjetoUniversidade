using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversidadeDiego.Data;
using UniversidadeDiego.Models;

namespace UniversidadeDiego.Controllers
{
    public class EstudantesController : Controller
    {
        private readonly EscolaContexto _context;

        public EstudantesController(EscolaContexto context)
        {
            _context = context;
        }

        //'async' diz ao compilador para gerar callbacks  para partes do método e para criar automaticamente o objeto Task<IActionResult> que é retornado;
        //O tipo de retorno 'Task<IActionResult>' representa o trabalho em andamento com o resultado do tipo IActionResult;
        //'await' faz com que o compilador divida o método em partes.A primeira parte termina com a operação que é iniciada assincronamente e a segunda parte é posta no método callback quando a operãção termina;
        //'ToListAsync' é a versão assíncrona do método de extensão ToList;

        // GET: Estudantes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Estudantes.ToListAsync());
        }

        // GET: Estudantes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var estudante = await _context.Estudantes
            //    .FirstOrDefaultAsync(m => m.EstudanteID == id);

            var estudante = await _context.Estudantes
                .Include(s => s.Matriculas)
                .ThenInclude(e => e.Curso)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.EstudanteID == id);

            if (estudante == null)
            {
                return NotFound();
            }

            return View(estudante);
        }

        // GET: Estudantes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Estudantes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        //Removendo 'EstudanteID' do atributo Bind porque EstudanteID será 
        //o valor da chave primária que o SQL Server definirá automaticamente 
        //quando a linha for inserida. A entrada do usuário não define o valor ID.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome,SobreNome,DataMatricula")] Estudante estudante)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(estudante);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbException /*ex*/)
            {
                //Logar o erro (descomente a variável ex e escreva um log
                ModelState.AddModelError("", "Não foi possível salvar. " +
                    "Tente novamente, e se o problema persistir " +
                    "chame o suporte.");
                throw;
            }
           
            return View(estudante);
        }

        // GET: Estudantes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estudante = await _context.Estudantes.FindAsync(id);
            if (estudante == null)
            {
                return NotFound();
            }
            return View(estudante);
        }

        // POST: Estudantes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]      //especificando o ActionName que é chamado no 'Edit.cshtml'
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //recebe o estudante a partir da id recebida
            var atualizaEstudante = await _context.Estudantes.SingleOrDefaultAsync(s => s.EstudanteID == id);

            if (await TryUpdateModelAsync(
                atualizaEstudante, "", s => s.Nome, s => s.SobreNome, s => s.DataMatricula))
            {
                try
                {
                    await _context.SaveChangesAsync();  /*salva assincrono*/
                    return RedirectToAction("Index");   /*redireciona a index de 'Estudante'*/
                }
                catch (DbUpdateException /*ex*/)
                {
                    //Logar o erro (descomente a variável ex e escreva um log
                    ModelState.AddModelError("", "Não foi possível salvar. " +
                        "Tente novamente, e se o problema persistir " +
                        "chame o suporte.");
                }
            }
            return View(atualizaEstudante);
        }

        // GET: Estudantes/Delete/5
        public async Task<IActionResult> Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estudante = await _context.Estudantes
                .FirstOrDefaultAsync(m => m.EstudanteID == id);
            if (estudante == null)
            {
                return NotFound();
            }

            return View(estudante);
        }

        // POST: Estudantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var estudante = await _context.Estudantes
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.EstudanteID == id);

            if (estudante == null)
            {
                return RedirectToAction("Index");
            }

            try
            {
                _context.Estudantes.Remove(estudante);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException /* ex */)
            {
                //Logar o erro
                return RedirectToAction("Delete", new { id, saveChangesError = true });
            }
            
        }

        private bool EstudanteExists(int id)
        {
            return _context.Estudantes.Any(e => e.EstudanteID == id);
        }
    }
}
