import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RoleService {

  constructor(private http: HttpClient,
    @Inject('BASE_URL')private baseUrl: string) { }

  getRoles(): Observable<Role[]> {
    return this.http.get<Role[]>(this.baseUrl + '/api/role');
  }
}

export interface Role {
  id: string;
  name: string;
  inRole?: boolean;
}
