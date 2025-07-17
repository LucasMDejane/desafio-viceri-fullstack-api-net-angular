
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms'; 
import { HttpClient } from '@angular/common/http'; 
import { CommonModule } from '@angular/common';


interface EstudanteData {
  nome: string;
  idade: number | null;
  notas: NotaData[];
}

interface NotaData {
  disciplina: string;
  nota: number | null;
}



@Component({
  selector: 'app-cadastro-estudante',
  templateUrl: './cadastro-estudante.component.html', 
  styleUrls: ['./cadastro-estudante.component.css'], 
  standalone: true,
  imports: [ 
    FormsModule, 
    CommonModule
  ]
})
export class CadastroEstudanteComponent {

  estudante: EstudanteData = {
    nome: '',
    idade: null,
    notas: [
      { disciplina: '', nota: null } // nota vazia inicial
    ]
  };

  // injeta o HttpClient no construtor
  constructor(private http: HttpClient) { } 

  // lógica 

  adicionarNota(): void {
    this.estudante.notas.push({ disciplina: '', nota: null });
    console.log('Nova linha de nota adicionada.');
  }

  removerNota(index: number): void {
    if (this.estudante.notas.length > 1) {
      this.estudante.notas.splice(index, 1);
      console.log('Linha de nota removida.');
    } else {
      console.warn('Não é possível remover a última nota. Adicione outra antes de remover.');
    }
  }

  salvarEstudante(): void {
    if (!this.estudante.nome || this.estudante.nome.trim() === '') {
      alert('Por favor, preencha o nome do estudante.');
      return;
    }
    if (this.estudante.idade === null || this.estudante.idade <= 0) {
      alert('Por favor, insira uma idade válida (maior que 0).');
      return;
    }
    for (const nota of this.estudante.notas) {
      if (!nota.disciplina || nota.disciplina.trim() === '') {
        alert('Por favor, preencha a disciplina para todas as notas.');
        return;
      }
      if (nota.nota === null || nota.nota < 0 || nota.nota > 10) {
        alert('Por favor, insira uma nota válida (entre 0 e 10) para todas as disciplinas.');
        return;
      }
    }

    console.log('Enviando dados para a API:', this.estudante);

    const apiUrl = 'https://localhost:7249/api/Estudantes'; //url porta

    this.http.post(apiUrl, this.estudante).subscribe({
      next: (response: any) => {
        console.log('Resposta da API (Sucesso):', response);
        alert('Estudante cadastrado com sucesso!');
        this.estudante = {
          nome: '',
          idade: null,
          notas: [{ disciplina: '', nota: null }]
        };
      },
      error: (error: any) => {
        console.error('Erro na API:', error);
        let errorMessage = 'Ocorreu um erro ao cadastrar o estudante.';
        if (error.error && error.error.message) {
          errorMessage = `Erro da API: ${error.error.message}`;
        } else if (error.message) {
          errorMessage = `Erro de rede: ${error.message}`;
        }
        alert(errorMessage);
      }
    });
  }
}
