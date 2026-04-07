import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PhotoRequestsService {

  private apiUrl: string = "https://localhost:7279/api/gestores"; 
  constructor(private http: HttpClient) {

  }

  getPhotos(): Observable<any[]> {
    return this.http.get<any[]>(this.apiUrl);
  }

}
