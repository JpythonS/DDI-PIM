import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormBuilder, FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.page.html',
  styleUrls: ['./login.page.scss'],
})
export class LoginPage implements OnInit {
  emailControl: FormControl;
  passwordControl: FormControl;

  constructor(
    private formBuilder: FormBuilder,
    private httpClient: HttpClient,
    private router: Router
  ) {
    this.passwordControl = this.formBuilder.control('', [Validators.required]);
    this.emailControl = this.formBuilder.control('', [
      Validators.required,
      Validators.email,
    ]);
  }

  ngOnInit() {}

  login() {
    const apiUrl = 'http://localhost:5294/api/auth/login';
    const credentials = {
      email: this.emailControl.value,
      senha: this.passwordControl.value,
    };

    this.httpClient.post(apiUrl, credentials).subscribe({
      next: (response: any) => {
        const authToken = response.token;

        localStorage.setItem('authToken', authToken);

        this.router.navigate(['/home']);
      },
      error: () => {
        console.log('erro na autenticação');
      },
    });
  }
}
