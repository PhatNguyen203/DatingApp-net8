import { HttpClient } from '@angular/common/http';
import { Component, OnInit, inject } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  standalone: false,
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit{
  http = inject(HttpClient);
  title = 'Hello DatingApp';
  users: any; 

  ngOnInit(): void {
    this.http.get("http://localhost:5000/api/users")
      .subscribe({
        next: (res) => { this.users = res },
        error: (error) => { console.error(error) },
        complete: () => { console.log("The request has completed") }
      });
  }
}
