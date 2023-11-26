// main.js
$(document).ready(function() {
    // Listen for changes on the radio buttons
    $('input[name="meetingType"]').change(function() {
        var selectedType = $(this).val();
        var targetTable = selectedType === 'Corporate' ? 'Corporate_Customer_Tbl' : 'Individual_Customer_Tbl';
        
        // AJAX call to get the customer names
        $.ajax({
            url: '/path/to/your/server/endpoint', // Replace with your actual server endpoint
            type: 'GET',
            data: { targetTable: targetTable },
            success: function(response) {
                // Assuming 'response' is an array of customer names
                var options = response.map(function(customer) {
                    return `<option value="${customer.id}">${customer.name}</option>`;
                });
                $('#customerName').html(options.join(''));
            },
            error: function(error) {
                console.log(error);
            }
        });
    });
});
