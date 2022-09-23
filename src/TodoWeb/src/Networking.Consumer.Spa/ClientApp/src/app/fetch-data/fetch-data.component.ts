import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public todos: Todo[] = [];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Todo[]>(baseUrl + 'todo').subscribe(result => {
      this.todos = result;
    }, error => console.error(error));
  }
}

interface Todo {
  date: string;
  id: number;
  name: string;
  description: string;
}
