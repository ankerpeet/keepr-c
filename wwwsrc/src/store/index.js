import axios from 'axios'
import vue from 'vue'
import vuex from 'vuex'
import router from '../router'

let api = axios.create({
  baseURL: 'http://localhost:5000/api/',
  timeout: 10000,
  withCredentials: true
})

vue.use(vuex)

var store = new vuex.Store({
  state: {
    user: {},
    keeps: []
  },
  mutations: {
    setKeeps(state, data) {
      state.keeps = data
    },
    setUser(state, user) {
      state.user = user
    }
  },
  actions: {
    //Get all keeps
    getKeeps({ commit, dispatch }) {
      api('keeps').then(res => {
        commit('setKeeps', res.data)
      }).catch(err => {
        console.error(err)
      })
    },
    //Get User's Keeps
    getUserKeeps({ commit, dispatch }, userId) {
      api(`account/${userId}/keeps`).then(res => {
        commit('setKeeps', res.data)
      }).catch(err => {
        console.error(err)
      })
    },
    //Get a single keep by its Id
    getKeep({ commit, dispatch }, id) {
      api('keeps/' + id).then(res => {
        commit('setKeeps', res.data)
      }).catch(err => {
        console.error(err)
      })
    },

    //User sign up, logout, and login functions
    createUser({ commit, dispatch }, user) {
      api.post('account', user)
        .then(res => {
          commit('setUser', res.data);
          return router.push('/dashboard/' + res.data.id);
        })
    },
    login({ commit, dispatch }, user) {
      api.post('account/login', user)
        .then(res => {
          commit('setUser', res.data)
          return router.push('/dashboard/' + res.data.id);
        })
    },
    logout({ commit, dispatch }) {
      api.delete('account/logout')
        .then(commit('setUser', {}))
        return router.push('/');
    },

    auth({ commit, dispatch }) {
      api('account').then(res => {
        console.log("Auth Response", res.data)
        commit('setUser', res.data)
      })
    }
  }
})


export default store

