import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Project } from '../../Models/project.model';
import { BaseService } from '../base.service';

@Injectable({
  providedIn: 'root'
})
export class ProjectService extends BaseService {
  private apiUrl = 'https://localhost:7239/api/project';

  getProjects(): Observable<Project[]> {
    return this.get<Project[]>(this.apiUrl);
  }

  getProjectById(id: number): Observable<Project> {
    return this.get<Project>(`${this.apiUrl}/${id}`);
  }

  createProject(project: Project): Observable<Project> {
    return this.post<Project>(this.apiUrl, project);
  }

  updateProject(id: number, project: Project): Observable<any> {
    return this.put(`${this.apiUrl}/${id}`, project);
  }

  deleteProject(id: number): Observable<any> {
    return this.delete(`${this.apiUrl}/${id}`);
  }
}
