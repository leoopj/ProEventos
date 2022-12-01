import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos', //define nome para instanciar componente
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {

  public eventos: any = [];
  public eventosFiltrados: any = [];
  widthImg: number = 50;
  margimImg: number = 2;
  viewImage: boolean = true;
  private _filtroLista: string = '';

  public get filtroLista(): string
  {
    return this._filtroLista;
  }

  public set filtroLista(value: string)
  {
    this._filtroLista = value;
    this.eventosFiltrados = this.filtroLista ? this.filtraEventos(this.filtroLista) : this.eventos
  }

  filtraEventos(filtraPor: string): any
  {
    filtraPor = filtraPor.toLocaleLowerCase();
    return this.eventos.filter(
      (evento: any) => evento.tema.toLocaleLowerCase().indexOf(filtraPor) !== -1
      || evento.local.toLocaleLowerCase().indexOf(filtraPor) !== -1
    )
  }

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.getEventos();
  }

  alterViewImage(){
    this.viewImage = !this.viewImage;
  }

  public getEventos(): void
  {
    //chamada de API
    this.http.get('https://localhost:5001/api/eventos').subscribe(
      response =>
      {
        this.eventos = response,
        this.eventosFiltrados = this.eventos
      },
      error => console.log(error)
    );

  }

}
