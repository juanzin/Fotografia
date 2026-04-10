import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CategoryRequestsService {

  private apiUrl: string = "https://localhost:7063/api/Categories";
  
    constructor(private http: HttpClient) {
  
    }
  
    getCategories(): Observable<any[]> {
      return this.http.get<any[]>(this.apiUrl);
    }

    getGallery(id: number): Observable<any[]> {
      return this.http.get<any[]>(this.apiUrl+"/getgaleria");
    }
}
