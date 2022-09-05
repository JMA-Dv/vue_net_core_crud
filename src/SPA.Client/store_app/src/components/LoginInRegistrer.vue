<template>

  <div class="columns is-centered">
    <div class="column is-7">

      <div class="box">
        <div class="tabs is-boxed">
          <ul>
            <li :class="{ 'is-active': tab === 'login' }">
              <a @click="tab = 'login'">Login</a>
            </li>
            <li :class="{ 'is-active': tab === 'register' }">
              <a @click="tab = 'register'">Registro</a>
            </li>
          </ul>
        </div>
        <Transition name="slide-fade">

          <form @submit.prevent="processForm" v-if="tab === 'login'">

            <div class="field">
              <label class="label">Email</label>
              <div class="control">
                <input v-model.trim="user.email" class="input" :class="{ 'is-danger': errorMessage.type === 'EMAIL' }"
                  type="email" placeholder="Email@example.com">
              </div>
              <p v-if="errorMessage.type === 'EMAIL'" class="help is-danger">This email is invalid</p>
            </div>

            <div class="field">
              <label class="label">Password</label>
              <div class="control">
                <input class="input" v-model="user.password" type="password" placeholder="example">
              </div>
            </div>

            <div class="field  is-grouped-centered">
              <div class="control">
                <button class="button is-link">Log In</button>
              </div>
            </div>
          </form>
        </Transition>

        <Transition name="slide-fade">

          <form @submit.prevent="processForm" v-if="tab === 'register'">

            <div class="field">
              <label class="label">First Name</label>
              <div class="control ">
                <input class="input" type="text" placeholder="example example" v-model="user.firstName">
              </div>
            </div>

            <div class="field">
              <label class="label">Last Name</label>
              <div class="control ">
                <input class="input" type="text" placeholder="example example" v-model="user.lastName">
              </div>
            </div>

            <div class="field">
              <label class="label">Email</label>
              <div class="control">
                <input v-model.trim="user.email" class="input" :class="{ 'is-danger': errorMessage.type === 'EMAIL' }"
                  type="email" placeholder="Email@example.com">
              </div>
              <p v-if="errorMessage.type === 'EMAIL'" class="help is-danger">This email is invalid</p>
            </div>

            <div class="field">
              <label class="label">Password</label>
              <div class="control">
                <input v-model.trim="user.password" class="input"
                  :class="{ 'is-danger': errorMessage.type === 'PASSWORD' }" type="password" placeholder="********">
              </div>
              <p v-if="errorMessage.type === 'PASSWORD'" class="help is-danger">Password </p>
            </div>

            <div class="field  is-grouped-centered">
              <div class="control">
                <button class="button is-link">Log In</button>
              </div>
            </div>
          </form>
        </Transition>

      </div>
    </div>

  </div>
</template>

<script>
import { ref } from 'vue'
export default {
  setup() {
    // const email = ref('');
    // const firstName = ref('');
    // const lastName = ref('');
    const errorMessage = ref('');
    const tab = ref('login')

    const user = ref({
      email: '',
      firstName: '',
      lastName: ''
    })

    const processForm = () => {
      if (!user.value.email.value.trim()) {
        errorMessage.value = "EMAIL";
        return;
      }

      if (!user.value.firstName.value.trim()) {
        errorMessage.value = "FIRST_EMAIL";
        return;
      }

      if (!user.value.lastName.value.trim()) {
        errorMessage.value = "LAST_EMAIL";
        return;
      }

      console.log(user.value)
    }

    return { processForm, user, errorMessage, tab }

  }
}
</script>
<style>
/*
  Enter and leave animations can use different
  durations and timing functions.
*/
.slide-fade-enter-active {
  transition: all 0.3s ease-out;
  transition-delay: 0.4s;
  
}

.slide-fade-leave-active {
  transition: all 0.1s cubic-bezier(1, 0.5, 0.8, 1);
  
}

.slide-fade-enter-from,
.slide-fade-leave-to {
  transform: translateX(20px);
  opacity: 0;
}
</style>