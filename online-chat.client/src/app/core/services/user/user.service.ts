import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, of } from 'rxjs';
import { AddUserRequest } from 'src/app/shared/models/user/add-user-request.model';
import { User } from 'src/app/shared/models/user/user.model';
import { environment } from 'src/environments/environment.development';

@Injectable({
  providedIn: 'root'
})

export class UserService {

  constructor(private http: HttpClient) { }

  addUser(model: AddUserRequest): Observable<User> {
    return this.http.post<User>(`${environment.apiBaseUrl}/api/user`, model);
  }

  getAllUsers(): Observable<User[]> {
    return this.http.get<User[]>(`${environment.apiBaseUrl}/api/user`);
  }

  getUserById(id: string): Observable<User> {
    return this.http.get<User>(`${environment.apiBaseUrl}/api/user/${id}`);
  }

  getUserByName(name: string): Observable<any> {
    return this.http.get<User>(`${environment.apiBaseUrl}/api/user/${name}`).pipe(
      catchError((error: HttpErrorResponse) => {
        if (error.status === 404) {
          return of(null);
        }
        throw error;
      })
    );;
  }
}
