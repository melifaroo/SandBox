<template>
  <div>
    <h1> <samp v-if="borrowings.length > 0">{{borrowings.length}}</samp><samp v-else>No</samp> Borrowing<samp v-show="borrowings.length != 1">s</samp> in register </h1>
    <div class="table-scroll">
      <table class="table table-striped mb-0" id="booksTable">
        <thead>
          <tr>
            <th style="display:none;"><label>Id</label></th>
            <th><label>Date</label></th>
            <th><label>Book</label></th>
            <th><label>Reader</label></th>
            <th><label>Term</label></th>
            <th><label>Return Date</label></th>
            <th><label>Controls</label></th>
          </tr>
        </thead>
        <tbody v-if="borrowings && borrowings.length">
          <tr v-for="borrowing of borrowings" v-bind:key="borrowing">
            <th scope="row" style="display:none;">{{ borrowing.borrowingId }}</th>
            <td align="right"><router-link class="btn btn-link" :to="'/library/borrowing/'+ borrowing.borrowingId">{{ borrowing.date }}</router-link></td>
            <td align="right"><router-link class="btn btn-link" :to="'/library/book/'+ borrowing.bookId">{{ borrowing.book }}</router-link></td>
            <td align="left"><label>by </label><router-link class="btn btn-link" :to="'/library/readers/'+ borrowing.readerId">{{ borrowing.reader }}</router-link></td>
            <td align="center"><label>for {{ borrowing.term }} days</label></td>
            <td align="center"><label>on {{ borrowing.returnDate }}</label></td>
            <td align="left">
              <router-link :aria-disabled="borrowing.closed" class="btn btn-warning" :to="'/library/borrowings/close/'+ borrowing.borrowingId">Close</router-link>
            </td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
</template>

<script>
    export default { props: { borrowings: { type: Array, default: () => [] } } };
</script>