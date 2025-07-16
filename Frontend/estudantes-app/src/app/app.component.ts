// src/app/app.component.ts
import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { CadastroEstudanteComponent } from './cadastro-estudante/cadastro-estudante.component';
import { HttpClientModule } from '@angular/common/http';

@Component({
  selector: 'app-root',
  
  standalone: true,
  imports: [
    RouterOutlet, 
    CadastroEstudanteComponent,
    HttpClientModule
  ],
  templateUrl: './app.component.html', 
  styleUrls: ['./app.component.css'] 
})
export class AppComponent { 
  title = 'estudantes-app';
  protected readonly titleSignal = signal('estudantes-app'); 
}
