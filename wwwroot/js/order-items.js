$(document).ready(function () {
    let groupClone
    $(".order-items").each(function () {
        const orderBox = $(this)
        const items = orderBox.children('.order-items-container')
        const mealIdx = orderBox.attr("data-meal")
        orderBox.find(".order-items-more").on("click", function () {
            if(!groupClone)
                groupClone=items.find(".order-form-group:first")
            groupClone.clone().appendTo(items)
            let count = 0
            items.find(".order-form-group").each(function(rowIdx){
                count++;
                const Row = $(this)
                Row.attr("id", `item-${rowIdx}`)
                Row.find("select").attr("name",`Meals[${mealIdx}][${rowIdx}]`)
                Row.find(".order-items-remove").attr("data-target", `#item-${rowIdx}`).on("click", remove)
            })
            orderBox.attr("data-count", count)
        })
        function remove(){
            const count = +orderBox.attr("data-count") || 0
            const target = this.getAttribute("data-target")
            if (count > 0 && target) {
                console.log(orderBox, items, target)
                orderBox.find(target).remove()
                let count = 0;
                items.find(".order-form-group").each(function(){
                    count++;
                })
                orderBox.attr("data-count", count)
            }
        }
        orderBox.find(".order-items-remove").on("click", remove)
        
    })
})