import { Component, ElementRef, TemplateRef, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { Project } from '../../Models/project.model';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ProjectService } from '../../services/project-service/project.service';

@Component({
  selector: 'app-project',
  templateUrl: './project.component.html'
})
export class ProjectComponent {
  @ViewChild('ngbToast', { static: true }) ngbToast!: ElementRef;
  @ViewChild('updateModal') updateModal!: TemplateRef<any>;
  public projects: Project[] = [];
  public selectedProject: Project = new Project();
  public newProject: Project = new Project();
  public isEditing: boolean = false;
  toastMessage: string = '';
  showToastFlag: boolean = false;
  toastType: string = '';
  public isLoading: boolean = false;

  constructor(
    private projectService: ProjectService,
    private modalService: NgbModal,
    private router: Router) { }

  ngOnInit(): void {
    this.loadProjects();
  }

  loadProjects(): void {
    this.isLoading = true;
    this.projectService.getProjects().subscribe(
      (data: Project[]) => {
        this.projects = data;
        this.isLoading = false;
      },
      error => {
        this.showToast('Error loading projects', 'error');
        this.isLoading = false;
      }
    );
  }

  saveProject(): void {
    this.projectService.createProject(this.newProject).subscribe(
      (newProject: Project) => {
        this.projects.push(newProject);
        this.resetForm();
        this.showToast('Project added successfully!', 'success');
      },
      (error) => {
        console.error('Error creating project', error);
        this.showToast('Error creating project. Please try again.', 'error');
      }
    );
  }

  updateProject(modal: any): void {
    this.projectService.updateProject(this.selectedProject.id, this.selectedProject).subscribe(
      response => {
        this.showToast('Project updated successfully', 'success');
        modal.close();
        this.loadProjects();
      },
      error => {
        this.showToast('Error updating project', 'error');
      }
    );
  }

  openUpdateModal(project: Project): void {
    this.selectedProject = { ...project };
    this.modalService.open(this.updateModal);
    this.isEditing = true;
  }

  showToast(message: string, type: string): void {
    this.toastMessage = message;
    this.toastType = type;
    this.showToastFlag = true;
    setTimeout(() => this.showToastFlag = false, 3000);
  }

  resetForm(): void {
    this.newProject = { name: '', description: '', id: 0 };
    this.isEditing = false;
  }

  deleteProject(projectId: number) {
    this.projectService.deleteProject(projectId).subscribe(
      () => {
        this.projects = this.projects.filter(p => p.id !== projectId);
        this.showToast('Project deleted successfully!', 'success');
      },
      (error) => {
        console.error('Error deleting Project', error);
        this.showToast('Error deleting Project. Please try again.', 'error');
      }
    );
  }

  // For future navigation to a related component
  addExpense(project: Project): void {
    this.router.navigate(['/expenses'], {
      queryParams: { projectId: project.id, projectName: project.name }
    });
  }
}
