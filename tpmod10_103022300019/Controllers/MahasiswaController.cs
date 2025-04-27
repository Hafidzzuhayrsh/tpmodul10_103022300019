using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using tpmodul10_103022300019;

namespace MahasiswaApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MahasiswaController : ControllerBase
    {
        // Static list mahasiswa
        private static List<Mahasiswa> mahasiswas = new List<Mahasiswa>
        {
            new Mahasiswa { Nama = "HAFIDZZUHAYRS", Nim = "103022300019" },
            new Mahasiswa { Nama = "Maulana Jidan Azizi ", Nim = "103022300083" },
            new Mahasiswa { Nama = "Ahmad Naufal Al Ghiffari", Nim = "103022300006" },
            new Mahasiswa { Nama = "Wildan Nabil Ramdhany ", Nim = "103022300095" },
            new Mahasiswa { Nama = "Abizar Tsaqif Abrar", Nim = "103022330128" },
            new Mahasiswa { Nama = "Elvina Nilysti Huang", Nim = "103022300145" }
        };

        // GET: /api/mahasiswa
        [HttpGet]
        public ActionResult<IEnumerable<Mahasiswa>> GetAll()
        {
            return mahasiswas;
        }

        // GET: /api/mahasiswa/{index}
        [HttpGet("{index}")]
        public ActionResult<Mahasiswa> GetByIndex(int index)
        {
            if (index < 0 || index >= mahasiswas.Count)
            {
                return NotFound("Mahasiswa tidak ditemukan.");
            }
            return mahasiswas[index];
        }

        // POST: /api/mahasiswa
        [HttpPost]
        public ActionResult AddMahasiswa([FromBody] Mahasiswa newMahasiswa)
        {
            if (newMahasiswa == null || string.IsNullOrEmpty(newMahasiswa.Nama) || string.IsNullOrEmpty(newMahasiswa.Nim))
            {
                return BadRequest("Data mahasiswa tidak lengkap.");
            }

            mahasiswas.Add(newMahasiswa);
            return Ok("Mahasiswa berhasil ditambahkan.");
        }

        // DELETE: /api/mahasiswa/{index}
        [HttpDelete("{index}")]
        public ActionResult DeleteMahasiswa(int index)
        {
            if (index < 0 || index >= mahasiswas.Count)
            {
                return NotFound("Mahasiswa tidak ditemukan.");
            }

            mahasiswas.RemoveAt(index);
            return Ok("Mahasiswa berhasil dihapus.");
        }
    }
}
