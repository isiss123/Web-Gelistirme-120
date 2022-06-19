// Stroge Controller
const StrogeController = (function () {
    //private
    var storeProduct =(product)=>{
        let products
        if(localStorage.getItem('products') ===null){
            products = [];
            products.push(product);
            
        }else{
            products = JSON.parse(localStorage.getItem('products'));
            products.push(product)
        }
        localStorage.setItem('products',JSON.stringify(products))
    }
    var getProducts = ()=>{
        let products
        if(localStorage.getItem('products')==null){
            products = [];
        }else{
            products = JSON.parse(localStorage.getItem('products'));
        }
        return products;
    }
    var updateProduct =(product)=>{
        let products = JSON.parse(localStorage.getItem('products'))
        products.forEach(function (prd,index){
            if(product.id == prd.id){
                products.splice(index,1,product)
            }
        });
        localStorage.setItem('products',JSON.stringify(products))
    }
    var deleteProduct =(id) =>{
        let products = JSON.parse(localStorage.getItem('products'))
        products.forEach(function (prd,index){
            if(id == prd.id){
                products.splice(index,1)
            }
        });
        localStorage.setItem('products',JSON.stringify(products))
    }
    return {
        // public
        storeProduct,
        getProducts,
        updateProduct,
        deleteProduct
    }

})()


// Product Controller
const ProductController = (function () {
    //private
    const Product = function (id, name, price) {
        this.id = id,
            this.name = name,
            this.price = price
    };
    const data = {
        products: StrogeController.getProducts(),
        selectedProduct: null,
        totalPrice: 0
    }
    var getProduct = () => {
        return data.products
    }
    var getData = () => {
        return data
    }
    var addProduct = (name, price) => {
        let id;
        if (data.products.length > 0) {
            id = data.products[data.products.length - 1].id + 1
        } else {
            id = 0;
        }
        const newProduct = new Product(id, name, parseFloat(price))

        data.products.push(newProduct)
        return newProduct

    }
    var getTotal = () => {
        let total = 0;
        data.products.forEach(item => {
            total += item.price;
        })
        data.totalPrice = total;
        return data.totalPrice
    }
    var getProductById = (id) => {
        let product = null;
        data.products.forEach(prd => {
            if (prd.id == id) {
                product = prd
            }
        })
        return product;
    }
    var setCurrentProduct = (product) => {
        data.selectedProduct = product
    }
    var getCurrentProduct = () => {
        return data.selectedProduct;
    }
    var updateProduct = (name, price) => {
        let product = null;
        data.products.forEach(prd => {
            if (prd.id == data.selectedProduct.id) {
                prd.name = name;
                prd.price = parseFloat(price);
                product = prd
            }
        })
        return product
    }
    var deleteProduct = (product) =>{
        data.products.forEach(function(prd,index){
            if(prd.id == product.id){
                data.products.splice(index,1)
            }
        })
    }
    return {
        // public
        getProduct,
        getData,
        addProduct,
        getTotal,
        getProductById,
        setCurrentProduct,
        getCurrentProduct,
        updateProduct,
        deleteProduct
    }
})()

// UI Controller
const UIController = (function () {
    //private
    const Selectors = {
        productList: document.querySelector('#item-list'),
        productListItems: '#item-list tr',
        productName: document.querySelector('#productName'),
        productPrice: document.querySelector('#productPrice'),
        productCard: document.querySelector('#productCard'),
        totalAzn: document.querySelector('#total-azn'),
        totalDl: document.querySelector('#total-dl'),

        // btn
        addBtn: document.querySelector('.addBtn'),
        saveBtn: document.querySelector('.saveBtn'),
        deleteBtn: document.querySelector('.deleteBtn'),
        cancelBtn: document.querySelector('.cancelBtn'),

    }

    return {
        // public
        clearWarnings:()=>{
            let items = document.querySelectorAll(Selectors.productListItems)
            items.forEach(item=>{
                if(item.classList.contains('bg-warning')){
                    item.classList.remove('bg-warning')
                }
            })
        },
        getSelectors: function () {
            return Selectors
        },
        createProductList: (products) => {
            html = '';
            products.forEach(prd => {
                html += `
                <tr>
                    <td>${prd.id}</td>
                    <td>${prd.name}</td>
                    <td>${prd.price} $</td>
                    <td class="text-end"><i class="fa-solid fa-edit edit-product"></i></td>
                </tr>
                `
            })
            Selectors.productList.innerHTML = html;
        },
        addProduct: (prd) => {
            Selectors.productCard.style.display = 'block'
            let item = `
            <tr>
                    <td>${prd.id}</td>
                    <td>${prd.name}</td>
                    <td>${prd.price} $</td>
                    <td class="text-end"><i class="fa-solid fa-edit edit-product"></i></td>
                </tr>
            `
            Selectors.productList.innerHTML += item;
        },
        clearInputs: () => {
            Selectors.productName.value = '';
            Selectors.productPrice.value = '';
        },
        hideCard: () => {
            Selectors.productCard.style.display = 'none'
        },
        showTotal: (total) => {
            Selectors.totalDl.textContent = total;
            Selectors.totalAzn.textContent = total * 1.7;
        },
        addProductToForm: () => {
            const selectedProduct = ProductController.getCurrentProduct();
            productName.value = selectedProduct.name;
            productPrice.value = selectedProduct.price;
        },
        addingState: (item) => {
            UIController.clearWarnings()
            UIController.clearInputs()
            Selectors.addBtn.style.display = 'inline';
            Selectors.saveBtn.style.display = 'none';
            Selectors.deleteBtn.style.display = 'none';
            Selectors.cancelBtn.style.display = 'none';
        },
        editingState: (tr) => {
            tr.classList.add('bg-warning');
            Selectors.addBtn.style.display = 'none';
            Selectors.saveBtn.style.display = 'inline';
            Selectors.deleteBtn.style.display = 'inline';
            Selectors.cancelBtn.style.display = 'inline';
        },
        updateProduct: (prd) => {
            let updateItem = null
            let items = document.querySelectorAll(Selectors.productListItems)
            items.forEach(item => {
                if (item.classList.contains('bg-warning')) {
                    item.children[1].textContent = prd.name;
                    item.children[2].textContent = prd.price + ' $';
                    updateItem = item
                }
            })
            return updateItem
        },
        deleteProduct :() =>{
            let items = document.querySelectorAll(Selectors.productListItems)
            items.forEach(item=>{
                if(item.classList.contains('bg-warning')){
                    item.remove()
                }
            })
        }
    }
})()

// App Controller
const AppController = (function (UICtrl, ProductCtrl,StrogeCtrl) {
    //private
    const UISelectors = UICtrl.getSelectors()
    const loadEventListener = () => {
        // add product event 
        UISelectors.addBtn.addEventListener('click', productAddSubmmit);
        // edit product click
        UISelectors.productList.addEventListener('click', productEditClick);
        // edit product submit
        UISelectors.saveBtn.addEventListener('click', editProductSave);
        // cancel button click
        UISelectors.cancelBtn.addEventListener('click', cancalUpdate);
        // delete product submit 
        UISelectors.deleteBtn.addEventListener('click',deleteProductSumbit);
    }
    const productAddSubmmit = (e) => {
        const productName = UISelectors.productName.value;
        const productPrice = UISelectors.productPrice.value;
        if (productName != '' && productPrice != '') {
            // console.log(productName,productPrice);
            // Add Product
            const newProduct = ProductCtrl.addProduct(productName, productPrice)

            // Add item to list
            UICtrl.addProduct(newProduct)

            // Add item to Local Stroge
            StrogeCtrl.storeProduct(newProduct)
            // Total Price
            let total = ProductCtrl.getTotal();
            // Show Total
            UICtrl.showTotal(total)
            // Clear
            UICtrl.clearInputs()

            
            // console.log(newProduct)
        }

        e.preventDefault();
    }
    const productEditClick = (e) => {
        if (e.target.classList.contains('edit-product')) {
            UICtrl.clearWarnings()
            let id = e.target.parentNode.previousElementSibling.previousElementSibling.previousElementSibling.textContent

            // get selected product
            let product = ProductCtrl.getProductById(id);
            // console.log(product);

            // set current product
            ProductCtrl.setCurrentProduct(product)

            // add product to UI
            UICtrl.addProductToForm()
            UICtrl.editingState(e.target.parentNode.parentNode)
        }
    };

    const editProductSave = (e) => {
        const productName = UISelectors.productName.value;
        const productPrice = UISelectors.productPrice.value;

        if (productName != '' && productPrice != '') {

            // update product
            const updateProduct = ProductCtrl.updateProduct(productName, productPrice)

            // update ui
            const item = UICtrl.updateProduct(updateProduct)

            // update Stroge
            StrogeCtrl.updateProduct(updateProduct)

            // Total Price
            let total = ProductCtrl.getTotal();
            // Show Total
            UICtrl.showTotal(total);

            UICtrl.addingState()
        }

        e.preventDefault();
    };
    const cancalUpdate = (e)=>{
        UICtrl.addingState();
        UICtrl.clearWarnings();
        e.preventDefault();
    }
    const deleteProductSumbit = (e)=>{
        // get selected product
        let selectedProduct = ProductCtrl.getCurrentProduct()
        // delete product
        ProductCtrl.deleteProduct(selectedProduct)
        // delete UI
        UICtrl.deleteProduct();
        // Total Price
        let total = ProductCtrl.getTotal();
        // Show Total
        UICtrl.showTotal(total);

        // delete from stroge
        StrogeCtrl.deleteProduct(selectedProduct.id)
        UICtrl.addingState()
        if(total==0){
            UICtrl.hideCard()
        }
        
        e.preventDefault();
    }
    return {
        // public
        init: () => {
            console.log('Starting app...')
             // Total Price
             let total = ProductCtrl.getTotal();
             // Show Total
             UICtrl.showTotal(total);
            UICtrl.addingState()
            let products = ProductCtrl.getProduct()
            if (products.length == 0) {
                UICtrl.hideCard()
            } else {
                // console.log(products)
                UICtrl.createProductList(products)
            }
            loadEventListener()
        }
    }
})(UIController, ProductController,StrogeController)

AppController.init()